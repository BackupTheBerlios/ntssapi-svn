greekconverter 050306
---------------------
Java package for converting between various representations of polytonic Greek.
This version 06-Mar-2005 by Michael Neuhold

1) Contents
AsciiToBetacode.class
BetacodeToSPIonic.class
BetacodeToUnicode.class
BetacodeToUnicode$BetaSymbol.class
BibleWorksToBetacode.class
BibleWorksToUnicode.class
CodeCharts.class
DynShortArray.class
GreekConvCaps.class
GreekConverter.class
GreekFileConverter.class
GreekKeysToUnicode.class
MessageHandler.class
Nereus.class
UC.class
UnicodeDecompose.class
UnicodePrecompose.class
UnicodeToAscii.class
UnicodeToBetacode.class
UnicodeToGreekKeys.class
UnicodeToHtml.class
UnicodeToName.class
VersionInfo.class
README.txt

2) Installation
Copy the class files into a subdirectory called "greekconverter" (be sure to
match case - all characters must be lowercase!). To execute the class files you
need Sun's Java runtime environment v. 1.2 or higher.

3) Usage
If you want to convert a file you can use the command line tool GreekFileConverter
or use the simple GUI interface Nereus.

To invoke the first one, go to the directory where the greej.Nerkconverter subdirectory
resides, then enter on the command line:
java greekconverter.GreekFileConverter source_file destination_file conversion_mode
[-inputenc value] [-outputenc value]
To get a short explanation about the parameters type
java greekconverter.GreekFileConverter -?
For an example look at the author's homepage (link at the end of this file).

The GUI interface is self-explaining. Error messages are displayed at
the console window. Have a look at it! To invoke it, go to the directory
where the greekconverter subdirectory resides and type:
java greekconverter.Nereus

(java is the program name of Sun's Java interpreter.)

BE AWARE THAT THIS IS ALL IN BETA STATE. USE AT YOUR OWN RISK!

4) License
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

5) You can contact the author at <homepage.neuhold@aon.at>
or visit his homepage at
<http://members.aon.at/neuhold/palm/grkconv_en.html> (in English) or
<http://members.aon.at/neuhold/palm/grkconv.html> (in German)
