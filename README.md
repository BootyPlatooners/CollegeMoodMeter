OSURatchetMeter
===============

The OSU Ratchet Meter is a measurer of the 'ratchet' levels of Ohio State students throughout the semester.

Analysis is done through Twitter searches via the Twitter API. First, a list of Ohio State students is compiled by finding recent mentions of particular keywords and account mentions mostly used exclusively by Ohio State students. Then, a search for specific 'ratchet' keywords is done over the students' tweets over a specific semester. The number of occurences of these keywords per weekend are recorded, and a ratchet level is assigned to each weekend throughout the semester, along with a score for the semester as a whole.

## Team Members
- Kevin Payravi
    + The Ohio State University
    + 2017
    + Computer Science & Engineering
    + http://www.kevinpayravi.com/
- Ben Knisley
    + The Ohio State University
    + 2017
    + Computer Science & Engineering
- Eun-jai Kim
    + The Ohio State University
    + 2017
    + Computer Science & Engineering

##Keywords and Mentions to Identify Students
`#newtoOSU` `#osu18` `#osu17` `@OhioUnion` `@OUAB`

##JSON Objects & Parameters

###List of JSON Arrays:
* `sp13`: Array of Week Statistics Objects for Spring 2013.
* `au13`: Array of Week Statistics Objects for Autumn 2013.
* `sp14`: Array of Week Statistics Objects for Spring 2014.
* `statistics`: Array of Semester Statistics Objects for each semester. 

###Week Statistics Object Parameters
Each of the sixteen objects list the week number, calculated ratchet level, and the number of occurances of keywords.
* `weekNumberCount`: Number of the week in the semester (`1` - `16`).
* `ratchetLevel`: Level of ratchetness during the weekend.
* `turnupCount`: Number of occurrences during weekend.
* `turntCount`: Number of occurrences during weekend.
* `turntttCount`: Number of occurrences during weekend.
* `ratchetCount`: Number of occurrences during weekend.
* `drunkCount`: Number of occurrences during weekend.
* `crunkCount`: Number of occurrences during weekend.
* `wastedCount`: Number of occurrences during weekend.
* `blackout_drunkCount`: Number of occurrences during weekend.
* `blacked_outCount`: Number of occurrences during weekend.
* `alcoholCount`: Number of occurrences during weekend.
* `boozeCount`: Number of occurrences during weekend.
* `beerCount`: Number of occurrences during weekend.
* `smashedCount`: Number of occurrences during weekend.
* `drunkatOSUCount`: Number of occurrences during weekend.
* `partyCount`: Number of occurrences during weekend.
* `partyingCount`: Number of occurrences during weekend.
* `partiedCount`: Number of occurrences during weekend.
* `tgifCount`: Number of occurrences during weekend.
* `pukeCount`: Number of occurrences during weekend.
* `pukedCount`: Number of occurrences during weekend.
* `pukingCount`: Number of occurrences during weekend.
* `drunk_textCount`: Number of occurrences during weekend.
* `drunk_textingCount`: Number of occurrences during weekend.
* `laidCount`: Number of occurrences during weekend.
* `yoloCount`: Number of occurrences during weekend.

###Semester Statistics Object Parameters
Each of the three objects list the overall ratchet level and keyword counts for the entire semester.
* `semester`: Semester (`sp13` / `au14` / `sp14`)
* `ratchetLevelOverall`: Overall averaged ratchet level for the semester.
* `turnupCount`: Number of occurrences in semester.
* `turntCount`: Number of occurrences in semester.
* `turntttCount`: Number of occurrences in semester.
* `ratchetCount`: Number of occurrences in semester.
* `drunkCount`: Number of occurrences in semester.
* `crunkCount`: Number of occurrences in semester.
* `wastedCount`: Number of occurrences in semester.
* `blackout_drunkCount`: Number of occurrences in semester.
* `blacked_outCount`: Number of occurrences in semester.
* `alcoholCount`: Number of occurrences in semester.
* `boozeCount`: Number of occurrences in semester.
* `beerCount`: Number of occurrences in semester.
* `smashedCount`: Number of occurrences in semester.
* `drunkatOSUCount`: Number of occurrences in semester.
* `partyCount`: Number of occurrences in semester.
* `partyingCount`: Number of occurrences in semester.
* `partiedCount`: Number of occurrences in semester.
* `tgifCount`: Number of occurrences in semester.
* `pukeCount`: Number of occurrences in semester.
* `pukedCount`: Number of occurrences in semester.
* `pukingCount`: Number of occurrences in semester.
* `drunk_textCount`: Number of occurrences in semester.
* `drunk_textingCount`: Number of occurrences in semester.
* `laidCount`: Number of occurrences in semester.
* `yoloCount`: Number of occurrences in semester.
