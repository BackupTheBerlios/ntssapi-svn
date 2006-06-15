<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
	<xsl:template match="/">
		<html>
			<head/>
			<body>
				<xsl:apply-templates/>
			</body>
		</html>
	</xsl:template>
	<xsl:template match="CHAPTER">
		<xsl:apply-templates/>
	</xsl:template>
	<xsl:template match="VERS">:<xsl:for-each select="@vnumber">
			<xsl:value-of select="."/>
		</xsl:for-each>&#160;<span style="color:black">
			<xsl:apply-templates/>
		</span>
		<br/>
	</xsl:template>
</xsl:stylesheet>
