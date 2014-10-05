College Mood Meter
===============

Welcome to College Mood Meeter: a Twitter analysis program that identifies students from particular colleges and determines the schools' overall mood levels in the following categories:

- Happiness
- Sadness
- Stress (midterm week, anyone?)
- Ratchetness (how fun, rowdy, and debaucherous students can be)

Analysis is done through Twitter searches via the Twitter API. First, a list of students from each college is compiled by finding recent mentions of particular keywords and account mentions used most exclusively by current students from that particular college. The last 200 tweets for each of these users is then compiled. The most commonly occuring words are recorded, along with performing a search for specific keywords that indicate each of the four moods. Then, the number of occurences of these keywords are recorded. Using the extracted data, mood levels are assigned to each of the colleges based on the keyword occurrence counts.

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
`happy` `excited` `ecstatic` `glad` `:)` `:D` `happiness` `yes` `fun` `good` `yay` `win` `laughing` `better` `love` `friends` `family` `easy` `happiest` `nice` `kind` `hilarious` `funny` `^^` `passed` `laugh` `loving` `winning` `kindness` `;)` `:-)` `:]` `;]` `xD` 
### Sadness
`sad` `miserable` `sucks` `hate` `:(` `D:` `fml` `sadness` `shitty` `worst` `suck` `lose` `crying` `miss` `enemies` `bad` `hard` `sin` `saddest` `rude` `impolite` `stupid` `idiot` `worthless` `useless` `fat` `gross` `disgusting` `disgust` `sick` `judgement` `saddening`  `;(` `:-(` `:[` `Dx` `mistake` `depressed` `depression` `sick` `depressing`
### Stress
`stress` `stressed` `midterm` `midterms` `homework` `finals` `exam` `exams` `job` `money` `wish` `more` `help` `procrastinate` `procrastination` `should've` `stressing` `studying` `late` `stressed out` `2am` `regret` `could've` `fail` `failed` `failure`
### Ratchetness
`turnup` `turnt` `turnttt` `ratchet` `drunk` `crunk` `wasted` `blackout drunk` `blacked out` `alcohol` `booze` `beer` `smashed` `drunkatOSU` `party` `partying` `partying` `partied` `tgif` `puke` `puked` `puking`  `laid` `yolo`

## Disclaimer
While this application is intended to give interesting insights and trends, the results of this analysis are not scientific. While a minority, some users identified as current students may be false positives, and the keywords used to gauge mood levels are not free from selection bias.
