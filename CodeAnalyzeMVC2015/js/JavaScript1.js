﻿SyntaxHighlighter.all();
SyntaxHighlighter.defaults.toolbar = false;


     

        function ValidateAnswer() {
            var content = tinyMCE.get('SolutionEditor').getContent()
            var VarEMail = document.getElementById('hfUserEMail').value;

            if (VarEMail != "") {
                if (content == "") {
                    alert("Please enter details");
                    return false;
                }
                else {
                    return true;
                }
            }
            else {
                alert("Please login to post");
                return false;
            }
        }

        function ValidateQues() {
            debugger;
            var title = document.getElementById('txtTitle').value;
            var ddType = $("#ddType").val();
            var content = tinyMCE.get('EditorAskQuestion').getContent()
            var VarEMail = document.getElementById('hfUserEMail').value;

            if (VarEMail != "") {
                if (content == "" && title == "" && type == "") {
                    alert("Please enter question title, type and details");
                    return false;
                }
                else if (content != "" && title == "" && type == "") {
                    alert("Please enter question title and type");
                    return false;
                }
                else if (content == "" && title != "" && type == "") {
                    alert("Please enter question type and details");
                    return false;
                }
                else if (content == "" && title == "" && type != "") {
                    alert("Please enter question title and content");
                    return false;
                }
                else if (content == "" && title != "" && type != "") {
                    alert("Please enter question title and content");
                    return false;
                }
                else if (content != "" && title != "" && type == "") {
                    alert("Please enter question title and content");
                    return false;
                }
                else if (content != "" && title == "" && type != "") {
                    alert("Please enter question title and content");
                    return false;
                }
                else
                    return true;
            }
            else {
                alert("Please login to post");
                return false;
            }
        }

        function ValidateComment() {
                var content = document.getElementById('txtReply').value;
                var VarEMail = document.getElementById('hfUserEMail').value;
                if (VarEMail != "") {
                    if (content == "" || content == "") {
                        alert("Please enter details");
                        return false;
                    }
                    else
                        return true;
                }
                else {
                    alert("Please login to post");
                    return false;
                }
        }

        function ValidatePostArticle() {
            var VarEMail = document.getElementById('hfUserEMail').value;
            var varArticleWordFile = document.getElementById('fileArticleWordFile').value;


            if (VarEMail != "") {
                if (varArticleWordFile == "") {
                    alert("Please select your article word file to post");
                    return false;
                }
                else {
                    if (varArticleWordFile.indexOf("docx") < 0 && varArticleWordFile.indexOf("doc") < 0 && varArticleWordFile.indexOf("DOCX") < 0 && varArticleWordFile.indexOf("DOC") < 0) {
                        alert('Invalid Format, please select only word doc.');
                        return false;
                    }
                    else {
                        return true;
                    }
                }

            }
            else {
                alert("Please login to post");
                return false;
            }
        }

        function ValidateUserReg() {
            var varFirstName = document.getElementById('FirstName').value;
            var varLastName = document.getElementById('LastName').value;
            var varEMail = document.getElementById('Email').value;
            var varDetails = document.getElementById('Details').value;
            var varPassword = document.getElementById('txtPassword').value;
            var varConfirmPassword = document.getElementById('txtConfirmPassword').value;
            var varAddress = document.getElementById('Address').value;

            if (varFirstName == "" || varLastName == "" || varEMail == "" || varDetails == "" || varPassword == "" || varConfirmPassword == "" || varAddress == "") {
                alert("Please enter all details. First and Last names, EMail, Password, Addess and Details");
                return false;
            }
            //else if (varFirstName == "" && varLastName == "" && varEMail == "" && varDetails == "" && varPassword == "" && varConfirmPassword == "") {
            //    alert("Please enter First and Last names, EMail, Password and Details");
            //    return false;
            //}
            //else if (varFirstName == "" && varLastName == "" && varEMail == "" && varPassword == "" && varConfirmPassword == "") {
            //    alert("Please enter First and Last names, EMail, Password");
            //    return false;
            //}
            //else if (varFirstName == "" && varLastName == "" && varPassword == "" && varConfirmPassword == "") {
            //    alert("Please enter First and Last names, EMail");
            //    return false;
            //}
            //else if (varFirstName == "" && varPassword == "" && varConfirmPassword == "") {
            //    alert("Please enter First and EMail"); return false;
            //    return false;
            //}
            else if (varPassword != varConfirmPassword) {
                alert("Confirm password not matching with Password");
                return false;
            }
            else if (varPassword.length < 8) {
                alert("Password is expected to be 8 charectors.");
                return false;
            }
            else
                return true;

        }
        
        function ValidateSuggestion() {
            var txtEMail = document.getElementById('txtEMail').value;
            var txtSuggestion = document.getElementById('txtSuggestion').value;


            if (txtEMail == "" || txtSuggestion == "") {
                alert("Please enter all details");
                return false;
            }
            else
                return true;

        }

        function ValidateLogin() {
            var userName = document.getElementById('txtEMailId').value;
            var pwd = document.getElementById('txtPassword').value;

            if (userName != "" && pwd != "") {
                return true;
            }
            else {
                alert("Please enter username and password");
                return false;
            }
        }


        function ValidateForgotPassword() {
            var userName = document.getElementById('txtEMailId').value;

            if (userName != "") {
                return true;
            }
            else {
                alert("Please enter email");
                return false;
            }
        }

        function ValidatePasswords() {
            var varHFOldPassword = document.getElementById('HFOldPassword').value;
            var varOldPassword = document.getElementById('txtPassword').value;
            var varNewPassword = document.getElementById('txtNewPassword').value;
            var varConfirmPassword = document.getElementById('txtConfirmPassword').value;
            var VarEMail = document.getElementById('hfUserEMail').value;

            if (VarEMail != "") {
                if (varHFOldPassword != varOldPassword) {
                    alert("Please enter correct Old Password");
                    return false;
                }
                else if (txtNewPassword != txtConfirmPassword) {
                    alert("Password and ConfirmPassword does not match");
                    return false;
                }
                else if (txtNewPassword.length < 8) {
                    alert("Password is expected to be 8 charectors.");
                    return false;
                }
                else
                    return true;
            }
            else {
                alert("Please login to post");
                return false;
            }
        }


