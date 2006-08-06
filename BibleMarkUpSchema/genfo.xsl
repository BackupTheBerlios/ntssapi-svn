<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
	<xsl:variable name="fo:layout-master-set">
		<fo:layout-master-set>
			<fo:simple-page-master master-name="default-page-master" page-height="11in" page-width="8.5in" margin-top="0.79in" margin-bottom="0.79in" margin-left="0.6in" margin-right="0.6in">
				<fo:region-before margin-right="0.6in" extent="0cm"/>
				<fo:region-body margin-top="0cm" margin-bottom="0cm" font-family="Helvetica,Times,Courier" font-size="14pt" line-height="16pt"/>
				<fo:region-after extent="0cm"/>
			</fo:simple-page-master>
		</fo:layout-master-set>
	</xsl:variable>
	<xsl:template match="/">
		<fo:root>
			<xsl:copy-of select="$fo:layout-master-set"/>
			<fo:page-sequence master-reference="default-page-master">
				<fo:static-content flow-name="xsl-region-before">
					<fo:block/>
				</fo:static-content>
				<fo:static-content flow-name="xsl-region-after">
					<fo:block/>
				</fo:static-content>
				<fo:flow flow-name="xsl-region-body">
					<fo:block/>
				</fo:flow>
			</fo:page-sequence>
		</fo:root>
	</xsl:template>
	<xsl:template match="GRAM">
		<xsl:apply-templates/>
	</xsl:template>
</xsl:stylesheet>
