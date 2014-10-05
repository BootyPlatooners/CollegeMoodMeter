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
`<3` `:)` `:-)` `:]` `:D` `;)` `;]` `^^` `better` `easy` `ecstatic` `excited` `family` `friends` `fun` `funny` `glad` `good` `happiest` `happiness` `happy` `hilarious` `kind` `kindness` `laugh` `laughing` `lol` `love` `loving` `nice` `passed` `win` `winning` `xD` `yay` `yes`
### Sadness
`:(` `:-(` `:[` `;(` `bad` `crying` `D:` `depressed` `depressing` `depression` `disgust` `disgusting` `Dx` `enemies` `fat` `fml` `gross` `hard` `hate` `idiot` `impolite` `judgement` `lose` `miserable` `miss` `mistake` `rude` `sad` `saddening` `saddest` `sadness` `shitty` `sick` `sin` `stupid` `suck` `sucks` `useless` `worst` `worthless`
### Stress
`2am` `could've` `exam` `exams` `fail` `failed` `failure` `finals` `help` `homework` `job` `late` `midterm` `midterms` `money` `more` `procrastinate` `procrastination` `regret` `should've` `stress` `stressed` `stressed` `stressing` `studying` `wish` `out`
### Ratchetness
`alcohol` `beer` `blacked` `blackout` `booty` `booze` `crunk` `drunk` `drunkatOSU` `laid` `partied` `party` `partying` `puke` `puked` `puking` `ratchet` `smashed` `tgif` `turnt` `turnttt` `turnup` `wasted` `yolo` `drunk`

## Disclaimer
While this application is intended to give interesting insights and trends, the results of this analysis are not scientific. While a minority, some users identified as current students may be false positives, and the keywords used to gauge mood levels are not free from selection bias.
