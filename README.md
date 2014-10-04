College Mood Meter
===============

Welcome to College Mood Meeter: a Twitter analysis program that identifies students from particular colleges and determines the schools' overall mood levels in the following categories:

- Happiness
- Sadness
- Stress (midterm week, anyone?)
- Ratchetness (how fun, rowdy, and debaucherous students can be)

Analysis is done through Twitter searches via the Twitter API. First, a list of students from each college is compiled by finding recent mentions of particular keywords and account mentions used most exclusively by those students. The last 200 tweets for each of these users are compiled. Then, the most commonly occuring words are recorded, along with a search for specific keywords that indicate each of the four moods. The the number of occurences of these keywords are recorded. Finally, using the extracted data, mood levels are assigned to each of the colleges based on the keyword occurrence counts.

The current program is built to analyze Ohio State and University of Michigan students, which can easily be expanded to other schools (or other user sets).

## Team Members
- Kevin Payravi
    + The Ohio State University
    + Graduating 2017
    + Computer Science & Engineering
    + http://www.kevinpayravi.com/
- Ben Knisley
    + The Ohio State University
    + Graduating 2017
    + Computer Science & Engineering
- Eun-jai Kim
    + The Ohio State University
    + Graduating 2017
    + Computer Science & Engineering

## Identifying Students: Keywords and Mentions
### Ohio State University
`#BuckeyeNation` `@OhioUnion` `@OUAB` `@OSUCrush` `@BuckeyeCrushes` `@TBDBITL` `@FakeUrban` `@TheFakeLantern` `@Brutus_Buckeye`

### University of Michigan
`@UMichUnions` `@UmichStudents` `@umichband` `@MMBStudents` `@UMStudentlife` `@crushes_umich`

## Mood Keywords
### Happiness
`happy` `excited` `can't wait` `ecstatic` `glad` `:)` `:D`
### Sadness
`sad` `miserable` `sucks` `hate` `:(` `D:`
### Stress
`stress` `stressed` `midterm` `midterms` `homework` `finals` `exam` `exams`
### Ratchetness
`turnup` `turnt` `turnttt` `ratchet` `drunk` `crunk` `wasted` `blackout drunk` `blacked out` `alcohol` `booze` `beer` `smashed` `drunkatOSU` `party` `partying` `partying` `partied` `tgif` `puke` `puked` `puking` `drunk text` `drunk texting` `laid` `yolo`
