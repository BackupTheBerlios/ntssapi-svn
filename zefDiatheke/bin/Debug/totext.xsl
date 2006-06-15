<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="text" version="1.0" encoding="UTF-8" indent="no"/>
	<xsl:template match="/">
		<xsl:apply-templates/>
	</xsl:template>
	<xsl:template match="INFORMATION">
	</xsl:template>
	<xsl:template match="VERS">
	<xsl:value-of select="../../@bname"/>
	<xsl:text> </xsl:text>
	<xsl:value-of select="../@cnumber"/>
	<xsl:text>:</xsl:text>
	<xsl:value-of select="@vnumber"/>
	<xsl:text> </xsl:text>
	<xsl:value-of select="."/>
	<xsl:text>
      </xsl:text>
	</xsl:template>
</xsl:stylesheet>
