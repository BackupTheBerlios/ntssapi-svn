<?php
/*********************************************
  CPG-NUKE: Advanced Content Management System
  ********************************************
  Copyright (c) 2004 by CPG-Nuke Dev Team
  http://www.cpgnuke.com

  CPG-Nuke is released under the terms and conditions
  of the GNU GPL version 2 or any later version

  $Source: /cvs/wysiwyg/htmlarea/htmlarea.php,v $
  $Revision: 1.3 $
  $Author: djmaze $
  $Date: 2005/01/23 04:18:25 $

***********************************************************************/
if (!defined('CPG_NUKE')) { exit; }

class HTMLArea
{
    var $header;
    var $fields = array();

    function HTMLArea()
    {
        $this->header = '';
    }

    function getHTML($field)
    {
        return '<textarea id="'.$field.'" name="'.$field.'" style="width: '.$this->fields[$field]['width'].'; height: '.$this->fields[$field]['height'].'">'
        .htmlspecialchars($this->fields[$field]['value'])
        ."</textarea>\n";
    }

    function setHeader()
    {
        global $modheader;
        $modheader .= '<script type="text/javascript">
  _editor_url = "includes/wysiwyg/htmlarea/";
  _editor_lang = "en";
</script>
<script type="text/javascript" src="includes/wysiwyg/htmlarea/htmlarea.js"></script>
<script type="text/javascript">
HTMLArea.loadPlugin("TableOperations");
HTMLArea.loadPlugin("CSS");
HTMLArea.loadPlugin("ContextMenu");
//HTMLArea.loadPlugin("HtmlTidy");
HTMLArea.loadPlugin("ListType");
HTMLArea.loadPlugin("CharacterMap");
HTMLArea.loadPlugin("DynamicCSS");

// this function will get called at body.onload
function initEditor() {
    // cache these values as we need to pass it for both editors
    var css_plugin_args = {
        combos : [
          { label: "Syntax",
                       // menu text       // CSS class
            options: { "None"           : "",
                       "Code" : "code",
                       "String" : "string",
                       "Comment" : "comment",
                       "Variable name" : "variable-name",
                       "Type" : "type",
                       "Reference" : "reference",
                       "Preprocessor" : "preprocessor",
                       "Keyword" : "keyword",
                       "Function name" : "function-name",
                       "Html tag" : "html-tag",
                       "Html italic" : "html-helper-italic",
                       "Warning" : "warning",
                       "Html bold" : "html-helper-bold"
                     },
            context: "pre"
          },
          { label: "Info",
            options: { "None"           : "",
                       "Quote"          : "quote",
                       "Highlight"      : "highlight",
                       "Deprecated"     : "deprecated"
                     }
          }
        ]
    };
'.$this->header.'
};
HTMLArea.onload = initEditor;
window.onload = HTMLArea.init();
</script>';
        $this->header = '';
    }

    function getInstance($control_name='richeditor', $width='100%', $height='300px', $value='') {
        static $instance;
        if (!isset($instance)) {
            $instance = new HTMLArea;
        }
        $instance->fields[$control_name] = array('width' => $width, 'height' => $height, 'value' => $value);
        $no = count($instance->fields);
        $instance->header .= "
    var editor$no = new HTMLArea(\"$control_name\");
    editor$no.registerPlugin(TableOperations);
    //editor$no.registerPlugin(HtmlTidy);
    editor$no.registerPlugin(ListType);
    editor$no.registerPlugin(CharacterMap);
    editor$no.registerPlugin(DynamicCSS);
    editor$no.registerPlugin(\"ContextMenu\");
    editor$no.config.pageStyle = \"@import url(custom.css);\";
    editor$no.generate();\n";
        return ($instance);
    }
}
