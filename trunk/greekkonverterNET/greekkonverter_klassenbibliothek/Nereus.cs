namespace greekconverter
{
	using System;
	using javax.swing;
	using javax.swing.event;
	/// <summary> Swing interface for the command line utility GreekFileConverter.
	/// *
	/// </summary>
	/// <version>  06-Mar-2005
	/// </version>
	/// <author>   Michael Neuhold
	/// </author>
	public class Nereus : ListSelectionListener
	{
		// some symbolic constants:
		private const int INPUT_ENCODING = 0;
		private const int OUTPUT_ENCODING = 1;
		private const int FULL_LIST = 0;
		private const int UNICODE_ONLY_LIST = 1;
		// layout:
		//UPGRADE_ISSUE: Class 'java.awt.GridBagLayout' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagLayout"'
		private GridBagLayout gridBag;
		//UPGRADE_ISSUE: Class 'java.awt.GridBagConstraints' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
		private GridBagConstraints gridCons;
		private JFrame mainFrame;
		private JPanel mainPane;
		// main window components:
		private JLabel srcLabel;
		private JTextField srcTf;
		private JButton srcBrowse;
		//
		private JLabel inpEncLabel;
		private JComboBox inpEncChoice;
		//
		private JLabel destLabel;
		private JTextField destTf;
		private JButton destBrowse;
		//
		private JLabel outpEncLabel;
		private JComboBox outpEncChoice;
		//
		private JLabel convLabel;
		private JList convList;
		private JScrollPane scrollPane;
		//
		private JButton startConv;
		private JButton exitProg;
		// dialogs:
		private JFileChooser fileDlg;
		private JOptionPane msgDlg;
		// choices:
		private JLabel namedEntLabel;
		private JComboBox namedEntChoice;
		private JLabel numberEntLabel;
		private JComboBox numberEntChoice;
		// file converter:
		private GreekFileConverter gfc;
		
		public static System.String getClassInfo(int infoType)
		{
			System.String info;
			
			switch (infoType)
			{
				
				case VersionInfo.CLASSINFO_VERSION_DATE:  info = "06-Mar-2005"; break;
				
				case VersionInfo.CLASSINFO_PROG_DESCR:  info = "Swing-GUI for class GreekFileConverter"; break;
				
				case VersionInfo.CLASSINFO_DEVELOPER:  info = "Michael Neuhold <michael.neuhold@aon.at>"; break;
				
				default:  info = "Felix qui potuit rerum cognoscere causas.";
					break;
				
			}
			return info;
		}
		
		/// <summary> Creates and lays out GUI components and makes the main window visible.
		/// </summary>
		private void  launchFrame()
		{
			System.Console.Out.WriteLine("Starting " + GetType().FullName);
			System.Console.Out.WriteLine("Version " + getClassInfo(0));
			gfc = new GreekFileConverter();
			//
			// create components
			//
			// source text field:
			srcLabel = new JLabel("Source file name:");
			srcTf = new JTextField("", 30);
			srcBrowse = new JButton("Browse...");
			srcBrowse.addActionListener(this);
			// input encoding:
			inpEncLabel = new JLabel("Input file encoding:");
			inpEncChoice = new JComboBox();
			createEncodingList(INPUT_ENCODING, FULL_LIST);
			// destination text field:
			destLabel = new JLabel("Destination file name:");
			destTf = new JTextField("", 30);
			destBrowse = new JButton("Browse...");
			destBrowse.addActionListener(this);
			// output encoding:
			outpEncLabel = new JLabel("Output file encoding:");
			outpEncChoice = new JComboBox();
			createEncodingList(OUTPUT_ENCODING, FULL_LIST);
			convLabel = new JLabel("Conversion:");
			// if you change the order of lines or insert a new line then change getConversionNumber too:
			System.String[] data = new System.String[]{"Unicode -> Betacode", "Unicode -> ASCII", "Unicode -> HTML", "Unicode -> GreekKeys", "Unicode -> Names", "Betacode -> Unicode", "Betacode -> SPIonic", "ASCII -> Betacode", "BibleWorks -> Unicode", "BibleWorks -> Betacode*", "GreekKeys -> Unicode", "Unicode -> Decomposed", "Unicode -> Precomposed"};
			convList = new JList(data);
			convList.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
			convList.setVisibleRowCount(5);
			convList.addListSelectionListener(this);
			scrollPane = new JScrollPane(convList);
			scrollPane.setVerticalScrollBarPolicy(JScrollPane.VERTICAL_SCROLLBAR_AS_NEEDED);
			// convert and exit buttons:
			startConv = new JButton("Convert");
			startConv.addActionListener(this);
			exitProg = new JButton("Exit");
			exitProg.addActionListener(this);
			// choices:
			namedEntLabel = new JLabel("Use named entities:");
			namedEntChoice = new JComboBox();
			namedEntChoice.addItem("where available");
			namedEntChoice.addItem("never");
			numberEntLabel = new JLabel("Numbers for entities are:");
			numberEntChoice = new JComboBox();
			numberEntChoice.addItem("decimal");
			numberEntChoice.addItem("hexadecimal");
			//
			// lay out the components
			//
			//UPGRADE_ISSUE: Constructor 'java.awt.GridBagLayout.GridBagLayout' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagLayout"'
			gridBag = new GridBagLayout();
			//UPGRADE_ISSUE: Constructor 'java.awt.GridBagConstraints.GridBagConstraints' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons = new GridBagConstraints();
			mainFrame = new JFrame(GetType().FullName + " v." + getClassInfo(0));
			mainPane = (JPanel) mainFrame.ContentPane;
			mainPane.setLayout(gridBag);
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.insets' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.insets = new System.Drawing.Rectangle(5, 5, 5, 5);
			// source file name:
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.gridwidth' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.gridwidth = 1;
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.fill' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.NONE' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.fill = GridBagConstraints.NONE;
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.anchor' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.EAST' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.anchor = GridBagConstraints.EAST;
			gridBag.setConstraints(srcLabel, gridCons);
			mainPane.add(srcLabel);
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.fill' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.VERTICAL' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.fill = GridBagConstraints.VERTICAL;
			gridBag.setConstraints(srcTf, gridCons);
			mainPane.add(srcTf);
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.gridwidth' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.REMAINDER' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.gridwidth = GridBagConstraints.REMAINDER;
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.fill' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.NONE' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.fill = GridBagConstraints.NONE;
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.anchor' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.CENTER' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.anchor = GridBagConstraints.CENTER;
			gridBag.setConstraints(srcBrowse, gridCons);
			mainPane.add(srcBrowse);
			// input encoding combobox:
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.gridwidth' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.gridwidth = 1;
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.anchor' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.EAST' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.anchor = GridBagConstraints.EAST;
			gridBag.setConstraints(inpEncLabel, gridCons);
			mainPane.add(inpEncLabel);
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.gridx' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.RELATIVE' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.gridx = GridBagConstraints.RELATIVE;
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.gridwidth' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.REMAINDER' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.gridwidth = GridBagConstraints.REMAINDER;
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.anchor' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.WEST' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.anchor = GridBagConstraints.WEST;
			gridBag.setConstraints(inpEncChoice, gridCons);
			mainPane.add(inpEncChoice);
			// destination file name:
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.gridwidth' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.gridwidth = 1;
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.anchor' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.EAST' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.anchor = GridBagConstraints.EAST;
			gridBag.setConstraints(destLabel, gridCons);
			mainPane.add(destLabel);
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.fill' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.VERTICAL' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.fill = GridBagConstraints.VERTICAL;
			gridBag.setConstraints(destTf, gridCons);
			mainPane.add(destTf);
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.gridwidth' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.REMAINDER' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.gridwidth = GridBagConstraints.REMAINDER;
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.fill' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.NONE' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.fill = GridBagConstraints.NONE;
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.anchor' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.CENTER' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.anchor = GridBagConstraints.CENTER;
			gridBag.setConstraints(destBrowse, gridCons);
			mainPane.add(destBrowse);
			// output encoding combobox:
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.gridwidth' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.gridwidth = 1;
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.anchor' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.EAST' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.anchor = GridBagConstraints.EAST;
			gridBag.setConstraints(outpEncLabel, gridCons);
			mainPane.add(outpEncLabel);
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.gridx' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.RELATIVE' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.gridx = GridBagConstraints.RELATIVE;
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.gridwidth' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.REMAINDER' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.gridwidth = GridBagConstraints.REMAINDER;
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.anchor' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.WEST' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.anchor = GridBagConstraints.WEST;
			gridBag.setConstraints(outpEncChoice, gridCons);
			mainPane.add(outpEncChoice);
			// list of available conversions:
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.gridwidth' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.gridwidth = 1;
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.anchor' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.EAST' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.anchor = GridBagConstraints.EAST;
			gridBag.setConstraints(convLabel, gridCons);
			mainPane.add(convLabel);
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.gridheight' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.gridheight = 2;
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.fill' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.HORIZONTAL' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.fill = GridBagConstraints.HORIZONTAL;
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.anchor' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.WEST' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.anchor = GridBagConstraints.WEST;
			gridBag.setConstraints(scrollPane, gridCons);
			mainPane.add(scrollPane);
			// convert and exit buttons:
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.gridheight' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.gridheight = 1;
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.gridwidth' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.REMAINDER' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.gridwidth = GridBagConstraints.REMAINDER;
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.fill' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.NONE' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.fill = GridBagConstraints.NONE;
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.anchor' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.CENTER' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.anchor = GridBagConstraints.CENTER;
			gridBag.setConstraints(startConv, gridCons);
			mainPane.add(startConv);
			gridBag.setConstraints(exitProg, gridCons);
			mainPane.add(exitProg);
			// extra choices for conversion into HTML
			// named entities:
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.gridwidth' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.gridwidth = 1;
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.anchor' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.EAST' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.anchor = GridBagConstraints.EAST;
			gridBag.setConstraints(namedEntLabel, gridCons);
			mainPane.add(namedEntLabel);
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.gridx' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.RELATIVE' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.gridx = GridBagConstraints.RELATIVE;
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.gridwidth' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.REMAINDER' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.gridwidth = GridBagConstraints.REMAINDER;
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.anchor' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.WEST' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.anchor = GridBagConstraints.WEST;
			gridBag.setConstraints(namedEntChoice, gridCons);
			mainPane.add(namedEntChoice);
			// number entities:
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.gridwidth' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.gridwidth = 1;
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.anchor' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.EAST' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.anchor = GridBagConstraints.EAST;
			gridBag.setConstraints(numberEntLabel, gridCons);
			mainPane.add(numberEntLabel);
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.gridx' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.RELATIVE' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.gridx = GridBagConstraints.RELATIVE;
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.anchor' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			//UPGRADE_ISSUE: Field 'java.awt.GridBagConstraints.WEST' wurde nicht konvertiert. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javaawtGridBagConstraints"'
			gridCons.anchor = GridBagConstraints.WEST;
			gridBag.setConstraints(numberEntChoice, gridCons);
			mainPane.add(numberEntChoice);
			// but do not display on startup:
			namedEntLabel.setVisible(false);
			namedEntChoice.setVisible(false);
			numberEntLabel.setVisible(false);
			numberEntChoice.setVisible(false);
			// init dialog windows:
			fileDlg = new JFileChooser(); // "Choose source file" );
			msgDlg = new JOptionPane();
			// bring up main window:
			mainFrame.pack();
			mainFrame.addWindowListener(this);
			mainFrame.setVisible(true);
		}
		
		// error windows: this one with a message and a specified type:
		private void  errMsg(System.String msgText, int msgType)
		{
			System.String title;
			switch (msgType)
			{
				
				case JOptionPane.ERROR_MESSAGE:  title = "Error"; break;
				
				case JOptionPane.INFORMATION_MESSAGE:  title = "Information"; break;
				
				case JOptionPane.PLAIN_MESSAGE:  title = "Message"; break;
				
				case JOptionPane.WARNING_MESSAGE:  title = "Warning"; break;
				
				default:  title = "Read me";
					break;
				
			}
			msgDlg.showMessageDialog(mainFrame, msgText, title, msgType);
		}
		
		// error windows: this one with a message and default type error:
		private void  errMsg(System.String msgText)
		{
			errMsg(msgText, JOptionPane.ERROR_MESSAGE);
		}
		
		// create list for input and output encoding choices.
		// some conversions make only sense with Unicode as input and/or output
		// encoding, e.g. decomposed Unicode needs Unicode input and output.
		private void  createEncodingList(int direction, int listtype)
		{
			JComboBox targetChoice;
			
			if (direction == INPUT_ENCODING)
			{
				targetChoice = inpEncChoice;
			}
			else
			{
				targetChoice = outpEncChoice;
			}
			
			targetChoice.removeAllItems();
			switch (listtype)
			{
				
				case FULL_LIST: 
					targetChoice.addItem("Local charset");
					targetChoice.addItem("US-ASCII");
					targetChoice.addItem("ISO-8859-1");
					// do not break here! the following entries are needed too.
					goto case UNICODE_ONLY_LIST;
				
				case UNICODE_ONLY_LIST: 
					targetChoice.addItem("UTF-8");
					targetChoice.addItem("UTF-16");
					targetChoice.addItem("UTF-16BE");
					targetChoice.addItem("UTF-16LE");
					break;
				}
		}
		
		// return conversion mode number that corresponds to the list box entry index:
		private int getConversionNumber(int index)
		{
			int convMode;
			
			switch (index)
			{
				
				case 0:  convMode = GreekConvCaps.UNICODE_BETACODE; break;
				
				case 1:  convMode = GreekConvCaps.UNICODE_ASCII; break;
				
				case 2:  convMode = GreekConvCaps.UNICODE_HTML; break;
				
				case 3:  convMode = GreekConvCaps.UNICODE_GREEKKEYS; break;
				
				case 4:  convMode = GreekConvCaps.UNICODE_NAMES; break;
				
				case 5:  convMode = GreekConvCaps.BETACODE_UNICODE; break;
				
				case 6:  convMode = GreekConvCaps.BETACODE_SPIONIC; break;
				
				case 7:  convMode = GreekConvCaps.ASCII_BETACODE; break;
				
				case 8:  convMode = GreekConvCaps.BIBLEWORKS_UNICODE; break;
				
				case 9:  convMode = GreekConvCaps.BIBLEWORKS_BETACODE; break;
				
				case 10:  convMode = GreekConvCaps.GREEKKEYS_UNICODE; break;
				
				case 11:  convMode = GreekConvCaps.UNICODE_DECOMPOSE; break;
				
				case 12:  convMode = GreekConvCaps.UNICODE_PRECOMPOSE; break;
				
				default:  convMode = 0; // which will not be recognized by GreekFileConverter
					break;
				
			}
			return convMode;
		}
		
		// implementing ActionListener interface:
		public virtual void  actionPerformed(System.Object event_sender, System.EventArgs e)
		{
			int retVal = greekconverter.GreekFileConverter.SUCCESS;
			//UPGRADE_NOTE: Die java.util.EventObject.getSource-Methode muss sich in einer Ereignisbehandlungsmethode befinden, um ordnungsgemäß konvertiert werden zu können. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1171"'
			System.Object obj = event_sender;
			
			//
			// Convert button pressed:
			//
			if (obj == startConv)
			{
				System.String srcFile = srcTf.Text, destFile = destTf.Text, inputEnc, outputEnc;
				int index = convList.SelectedIndex, convMode, convFrom, convInto;
				
				// has a conversion been selected:
				if (index == - 1)
				{
					errMsg("You have to select a conversion from the list.");
					retVal = greekconverter.GreekFileConverter.ERR_GENERAL;
				}
				// check file parameters:
				if (retVal == greekconverter.GreekFileConverter.SUCCESS)
				{
					retVal = gfc.checkFileParams(srcFile, destFile);
				}
				// set some options and invoke conversion:
				if (retVal == greekconverter.GreekFileConverter.SUCCESS)
				{
					convMode = getConversionNumber(index);
					System.Console.Out.WriteLine("Converting " + srcFile + " using conversion " + convList.SelectedValue + " into " + destFile);
					
					// if Unicode->HTML read and set options:
					if (convMode == GreekConvCaps.UNICODE_HTML)
					{
						int namedMode = namedEntChoice.SelectedIndex;
						int numberMode = numberEntChoice.SelectedIndex;
						gfc.setOption(GreekConvCaps.HTML_ENTITY_MODE, namedMode + numberMode * 2);
					}
					// determine input file encoding:
					inputEnc = (System.String) inpEncChoice.SelectedItem;
					if (inputEnc.Equals("Local charset"))
					{
						inputEnc = null; // means local charset which is default
					}
					// determine output file encoding:
					outputEnc = (System.String) outpEncChoice.SelectedItem;
					if (outputEnc.Equals("Local charset"))
					{
						outputEnc = null; // means local charset which is default
					}
					// invoke conversion:
					//UPGRADE_ISSUE: Member "'java.awt.Cursor.getPredefinedCursor'" wurde in "'System.Windows.Forms.Cursor'" konvertiert, und kann einer ganzen Zahl nicht zugewiesen werden. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1086"'
					//UPGRADE_ISSUE: Member "'java.awt.Cursor.WAIT_CURSOR'" wurde in "'System.Windows.Forms.Cursors.WaitCursor'" konvertiert, und kann einer ganzen Zahl nicht zugewiesen werden. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1086"'
					mainPane.setCursor(System.Windows.Forms.Cursors.WaitCursor);
					retVal = gfc.convertFile(srcFile, destFile, convMode, inputEnc, outputEnc);
					//UPGRADE_ISSUE: Member "'java.awt.Cursor.getDefaultCursor'" wurde in "'System.Windows.Forms.Cursors.Default'" konvertiert, und kann einer ganzen Zahl nicht zugewiesen werden. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1086"'
					mainPane.setCursor(System.Windows.Forms.Cursors.Default);
				}
				
				// if there has been an error then launch an error window:
				if (retVal == greekconverter.GreekFileConverter.SUCCESS)
				{
					System.Console.Out.WriteLine("\nDone");
					errMsg("Done", JOptionPane.PLAIN_MESSAGE);
				}
				else
				{
					errMsg(gfc.ErrMsg);
				}
			}
			//
			// Browse for source file button pressed
			//
			else if (obj == srcBrowse)
			{
				fileDlg.setDialogTitle("Choose source file");
				retVal = fileDlg.showOpenDialog(mainFrame);
				if (retVal == JFileChooser.APPROVE_OPTION)
				{
					srcTf.setText(fileDlg.SelectedFile.Path);
				}
			}
			//
			// Browse for destination file button pressed
			//
			else if (obj == destBrowse)
			{
				fileDlg.setDialogTitle("Choose destination file");
				retVal = fileDlg.showSaveDialog(mainFrame);
				if (retVal == JFileChooser.APPROVE_OPTION)
				{
					destTf.setText(fileDlg.SelectedFile.Path);
				}
			}
			//
			// Exit button pressed
			//
			else if (obj == exitProg)
			{
				System.Console.Out.WriteLine("Good bye.");
				System.Environment.Exit(0);
			}
		}
		
		// implementing WindowListener interface:
		public virtual void  windowActivated(System.Object event_sender, System.EventArgs e)
		{
		}
		public virtual void  windowClosed(System.Object event_sender, System.EventArgs e)
		{
		}
		public virtual void  windowDeactivated(System.Object event_sender, System.EventArgs e)
		{
		}
		public virtual void  windowDeiconified(System.Object event_sender, System.EventArgs e)
		{
		}
		public virtual void  windowIconified(System.Object event_sender, System.EventArgs e)
		{
		}
		public virtual void  windowOpened(System.Object event_sender, System.EventArgs e)
		{
		}
		public virtual void  windowClosing(System.Object event_sender, System.ComponentModel.CancelEventArgs e)
		{
			System.Console.Out.WriteLine("Good bye.");
			System.Environment.Exit(0);
		}
		
		// implementing ListSelectionListener interface
		// only the list box has been registered for this event
		public virtual void  valueChanged(ListSelectionEvent e)
		{
			int index = convList.SelectedIndex;
			int convMode = getConversionNumber(index);
			int convFrom = GreekConvCaps.getConvInput(convMode);
			int convInto = GreekConvCaps.getConvOutput(convMode);
			
			// input encoding list contents and availability of list depends on the
			// selected conversion:
			switch (convFrom)
			{
				
				case GreekConvCaps.UNICODE: 
					createEncodingList(INPUT_ENCODING, UNICODE_ONLY_LIST);
					inpEncLabel.setEnabled(true);
					inpEncChoice.setEnabled(true);
					break;
				
				case GreekConvCaps.GREEKKEYS: 
					createEncodingList(INPUT_ENCODING, FULL_LIST); // to have "Local charset" as visible entry
					inpEncLabel.setEnabled(false);
					inpEncChoice.setEnabled(false);
					break;
				
				default: 
					createEncodingList(INPUT_ENCODING, FULL_LIST);
					inpEncLabel.setEnabled(true);
					inpEncChoice.setEnabled(true);
					break;
				
			}
			// output encoding list contents and availability of list depends on the
			// selected conversion:
			switch (convInto)
			{
				
				case GreekConvCaps.UNICODE: 
					createEncodingList(OUTPUT_ENCODING, UNICODE_ONLY_LIST);
					outpEncLabel.setEnabled(true);
					outpEncChoice.setEnabled(true);
					break;
				
				case GreekConvCaps.GREEKKEYS: 
					createEncodingList(OUTPUT_ENCODING, FULL_LIST); // to have "Local charset" as visible entry
					outpEncLabel.setEnabled(false);
					outpEncChoice.setEnabled(false);
					break;
				
				default: 
					createEncodingList(OUTPUT_ENCODING, FULL_LIST);
					outpEncLabel.setEnabled(true);
					outpEncChoice.setEnabled(true);
					break;
				
			}
			// extra choices for conversion into HTML:
			if (convInto == GreekConvCaps.HTML)
			{
				namedEntLabel.setVisible(true);
				namedEntChoice.setVisible(true);
				numberEntLabel.setVisible(true);
				numberEntChoice.setVisible(true);
				mainFrame.pack();
			}
			else
			{
				namedEntLabel.setVisible(false);
				namedEntChoice.setVisible(false);
				numberEntLabel.setVisible(false);
				numberEntChoice.setVisible(false);
				mainFrame.pack();
			}
		}
		
		[STAThread]
		public static void  Main(System.String[] args)
		{
			Nereus nereus = new Nereus();
			nereus.launchFrame();
		}
	}
}