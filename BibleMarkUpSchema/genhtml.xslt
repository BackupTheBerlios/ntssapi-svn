<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
	<xsl:template match="/">
		<html>
			<head/>
			<body/>
		</html>
	</xsl:template>
	<xsl:template match="GRAM">
		<xsl:if test="position()=1">
			<ul style="margin-bottom:0; margin-top:0" start="1" type="disc">
				<xsl:for-each select="../GRAM">
					<li>
						<xsl:apply-templates/>
					</li>
				</xsl:for-each>
			</ul>
		</xsl:if>
	</xsl:template>
</xsl:stylesheet>
