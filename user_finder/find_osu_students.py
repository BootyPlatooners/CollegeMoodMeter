#!/usr/bin/env python

from twython import Twython
twitter = Twython()

## App Keys
APP_KEY = '********'
APP_SECRET = '*******'
## User Keys
OAUTH_TOKEN = '*******'
OAUTH_TOKEN_SECRET = '*******'

twitter = Twython(APP_KEY, APP_SECRET, OAUTH_TOKEN, OAUTH_TOKEN_SECRET) ## Get Twitter Object


def ListRemoveDups(list):
  seen = []
  for item in list:
    if item not in seen:
      seen.append(item)
  return seen

def GetUsersByQuery(twitter, query):
  UserList = []

  Response = twitter.search(q=query, count=100)
  Tweets = Response['statuses']

  NumOfTweets = len(Tweets) ## Get number of tweets
  for TweetIndex in range(0, NumOfTweets):
    Tweet = Tweets[TweetIndex]
    ScreenName = Tweet['user']['screen_name']
    UserList.append(ScreenName)
  return UserList

SearchKeywords = ['OSUCrush','TheFakeLantern', 'Brutus_Buckeye', 'BuckeyeNation', 'BuckeyeCrushes', 'TBDBITL', 'FakeUrban']
OSUStudents = []
for Keyword in SearchKeywords:
  OSUStudents = OSUStudents + GetUsersByQuery(twitter, Keyword)

OSUStudents = ListRemoveDups(OSUStudents)

i = 0
for user in OSUStudents:
  i += 1
  print i, user