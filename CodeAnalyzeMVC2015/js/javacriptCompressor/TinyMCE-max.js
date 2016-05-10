﻿tinymce.init({
    mode: "textareas",
    plugins: [
        'paste',
        'autolink',
    ],
    menubar: false,
    toolbar: 'mybutton | bold italic | numlist | undo redo',
    statusbar: false,
    keep_styles: false,
    height: "300px",
    width: "98%",
    encoding: 'xml',
    force_br_newlines: true,
    force_p_newlines: false,
    forced_root_block: '',
    paste_auto_cleanup_on_paste: true,
    paste_remove_styles: true,
    paste_as_text: true,
    paste_remove_spans: true,
    paste_remove_styles_if_webkit: true,
    paste_strip_class_attributes: "all",
    setup: function (ed) {
        ed.on('init', function () {
            this.getDoc().body.style.fontSize = '13px';
            this.getDoc().body.pasteAsPlainText = true;
            tinyMCE.activeEditor.setContent('');
        });
        ed.pasteAsPlainText = true;
        ed.addButton('mybutton', {
            text: 'INSERT CODE',
            onclick: function () {
                tinymce.activeEditor.execCommand('mceInsertContent', false, '#codestart<br /><br />');
                var bm = tinyMCE.activeEditor.selection.getBookmark();
                tinymce.activeEditor.execCommand('mceInsertContent', false, '<br />#codeend');
                tinyMCE.activeEditor.selection.moveToBookmark(bm);
            }
        });
        ed.on('keyup', function (e) {
            var strPost = StringClean(tinyMCE.activeEditor.getContent())
            document.getElementById("divPreview").innerHTML = strPost;
            prettyPrint();
        });
    }
});

tinyMCE.activeEditor.setContent('');



function StringClean(strInput) {
    var strReply = strInput;
    strReply = strReply.replace(/'/g, '')

    strReply = strReply.replace(/\r\n            #codestart/g, "<pre class=\"prettyprint\" style=\"font-size:14px;\">");
    strReply = strReply.replace(/#codeend\r\n        /g, "</pre>");

    strReply = strReply.replace(/#codestart/g, "<pre>");
    strReply = strReply.replace(/#codeend/g, "</pre>");

    strReply = strReply.replace(/<br>\r\n/g, "\r\n");
    strReply = strReply.replace(/\r\n/g, "#####");
    strReply = strReply.replace(/<br>/g, "<br />");

    strReply = strReply.replace(/<\/pre><br>/g, "<\/pre>");

    strReply = strReply.replace(/<pre>/g, "<pre class=\"prettyprint\" style=\"font-size:14px;\">");
    strReply = strReply.replace(/<pre class=\"prettyprint\" style=\"font-size:14px;\"><br \/>/g, "<pre class=\"prettyprint\" style=\"font-size:14px;\">");
    strReply = strReply.replace(/<pre class=\"prettyprint\" style=\"font-size:14px;\"><br\/>/g, "<pre class=\"prettyprint\" style=\"font-size:14px;\">");

    strReply = strReply.replace(/#####/g, "\r\n");
    strReply = strReply.replace(/<\/pre><br \/>/g, "<\/pre>");
    strReply = strReply.replace(/<\/pre><br\/>/g, "<\/pre>");

    return strReply;
};