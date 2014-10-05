#!/usr/bin/env python
from twython import Twython
import time
import unicodedata

## App Keys
APP_KEY = '****'
APP_SECRET = '****'
OAUTH_TOKEN = '****'
OAUTH_TOKEN_SECRET = '****'

twitter = Twython(APP_KEY, APP_SECRET, OAUTH_TOKEN, OAUTH_TOKEN_SECRET) ## Get Twitter Object

def clear(): ## Clears Screen
	import sys
	sys.stderr.write( "\x1b[2J\x1b[H" )
	pass

def ListRemoveDups(list): ## Removes Duplicates in a list
  seen = []
  for item in list:
    if item not in seen:
      seen.append(item)
  return seen

def GetUsersByQuery(twitter, query): ## Returns Twitter users by query
  UserList = []

  Response = twitter.search(q=query, count=100)
  Tweets = Response['statuses']

  NumOfTweets = len(Tweets) ## Get number of tweets
  for TweetIndex in range(0, NumOfTweets):
    Tweet = Tweets[TweetIndex]
    ScreenName = Tweet['user']['screen_name']
    UserList.append(ScreenName)
  return UserList

def GetWordsFromUser(user):
  Words = []

  RawText = ''
  try:
    Tweets = twitter.get_user_timeline(screen_name='@' + user, count=200)
  except:
    print "Hit Rate Limit..."
    print "Waiting 16 Min"
    time.sleep(1000)
    Tweets = twitter.get_user_timeline(screen_name='@' + user, count=200)
    pass
  for tweet in Tweets:
    RawText += tweet['text'] + ' '

  RawText = RawText.replace('\n', ' ') ## Remove all linespaces
  RawText = RawText.strip()            ## Remove Whitespaces from begin and end

  while RawText.count(' ') != 1:
    Word = RawText[:RawText.index(' ')] ## Get First Word including white space
    RawText = RawText[RawText.index(' ')+1:] ## Get Rest of string minus white space

    ## Remove Common Punuation

    ## Exclude smiles:
    Smilies = [':)', 'D:', ';(', ':-(', ':[', 'Dx', ';)', ':-)', ':]', ';]', 'xD', '^^']
    if Word[-2:] not in Smilies:

			Word = Word.replace('.', '')
			Word = Word.replace(',', '')
			Word = Word.replace('+', '')
			Word = Word.replace('-', '')
			Word = Word.replace('=', '')
			Word = Word.replace('<', '')
			Word = Word.replace('>', '')
			Word = Word.replace(')', '')
			Word = Word.replace('(', '')
			Word = Word.replace('&', '')
			Word = Word.replace('^', '')
			Word = Word.replace('%', '')
			Word = Word.replace('$', '')
			Word = Word.replace('!', '')
			Word = Word.replace('?', '')
			Word = Word.replace('"', '')
			Word = Word.replace("'", '')
			Word = Word.replace(":", '')
			Word = Word.replace("amp;", '')

			Word = Word.replace(u'\U0001f60d', ':)')
			Word = Word.replace(u'\U0001f604', ':)')
			Word = Word.replace(u'\U0001f602', ':)')
			Word = Word.replace(u'\U0001f61d', ':)')

			Word = Word.replace(u'\u201c', '')
			Word = Word.replace(u'\U0001f497', '')
			Word = Word.replace(u'\U0001f388', '')
			Word = Word.replace(u'\U0001f44f', '')
			Word = Word.replace(u'\U0001f637', '')
			Word = Word.replace(u'\U0001f64c', '')
			Word = Word.replace(u'\U0001f64f', '')
			Word = Word.replace(u'\U0001f44d', '')
			Word = Word.replace(u'\U0001f49b', '')
			Word = Word.replace(u'\U0001f49e', '')
			Word = Word.replace(u'\u26ab\ufe0f', '')
			Word = Word.replace(u'\U0001f49b', '')
			Word = Word.replace(u'\u2026', '')
			Word = Word.replace(u'\u201d', '')

			Word = Word.replace(u'\u2764\ufe0f', '<3')

			Word = Word.replace('-', '')
			if Word[:1] == '#':
				Word = Word[1:]

    Word = Word.lower() ## Drop all Words to Lowercase

    if Word[:1] != '@' and Word[:4] != 'http' and Word != " ":## Dont add if URL or User
			Words.append(Word)
  return Words

OhioQuerys = ['OSUCrush','TheFakeLantern', 'Brutus_Buckeye', 'BuckeyeNation', 'BuckeyeCrushes', 'TBDBITL', 'FakeUrban'] ## Keywords to find Probable OSU Students
MichQuerys = ['UMichUnions', 'UmichStudents', 'umichband', 'MMBStudents', 'UMStudentlife', 'crushes_umich'] ## Keywords to find Probable $ichigan Students

clear()
print 'Compiling list of Ohio State Students...'
OsuStuds = []
for Query in OhioQuerys:
  OsuStuds += GetUsersByQuery(twitter, Query)
OsuStuds = ListRemoveDups(OsuStuds)

print 'Compiling list of Michigan Students...'
MichStuds = []
for Query in MichQuerys:
    MichStuds += GetUsersByQuery(twitter, Query)
MichStuds = ListRemoveDups(MichStuds)


## Cuts The Larger List down to the Size of the Smaller List
if len(OsuStuds) > len(MichStuds):
  OsuStuds = OsuStuds[:len(MichStuds)]
if len(MichStuds) > len(OsuStuds):
  MichStuds = MichStuds[:len(OsuStuds)]
#MichStuds = MichStuds[:5]
#OsuStuds = OsuStuds[:5]
print str(len(OsuStuds)) + ' Students from each school'
print str(len(OsuStuds) + len(MichStuds)) + ' Total'


OsuWords = []
print "Retreaving Ohio State Tweets..."
for User in OsuStuds:
  print "User: @" + User + "..."
  OsuWords += GetWordsFromUser(User)

MichWords = []
print "Retreaving Mitchigan Tweets..."
for User in MichStuds:
  print "User: @" + User + "..."
  MichWords += GetWordsFromUser(User)



print "Counting Items"

OsuWordDic = {}
for Word in OsuWords:
	if Word in OsuWordDic:  ## Add Word to Words, if Word is already in Words, incrment
		OsuWordDic[Word] += 1
	else:
		OsuWordDic[Word] = 1

MichWordDic = {}
for Word in MichWords:
	if Word in MichWordDic:  ## Add Word to Words, if Word is already in Words, incrment
		MichWordDic[Word] += 1
	else:
		MichWordDic[Word] = 1


print "Writing to Files"
OsuFile = open('./Osu.txt', 'w')
MichFile = open('./Mich.txt', 'w')

for key, value in OsuWordDic.iteritems():
	OsuFile.write(key.encode('utf8') + ' ' + str(value) + '\n')
	print key.encode('utf8') + ' ' + str(value)

for key, value in MichWordDic.iteritems():
	MichFile.write(key.encode('utf8') + ' ' + str(value) + '\n')

OsuFile.close()
MichFile.close()

print 'Fin!'
