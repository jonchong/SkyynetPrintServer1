<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SkyyNet Login</title>
     
    
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 233px;
        }
        .auto-style3 {
            width: 154px;
            height: 87px;
        }
        .auto-style4 {
            width: 290px;
        }
        .auto-style5 {
            width: 402px;
        }
        .auto-style6 {
            width: 1024px;
            height: 768px;
        }
        .auto-style7 {
            width: 127px;
            height: 83px;
        }
        .auto-style8 {
            width: 233px;
            height: 104px;
        }
        .auto-style9 {
            width: 402px;
            height: 104px;
        }
        .auto-style10 {
            height: 104px;
        }
    </style>
     
    
</head>
<body>
    
    <div id="fb-root"></div>
        <script type="text/javascript">
            window.fbAsyncInit = function () {
                FB.init({ appId: '346041422164974', status: true, cookie: true, xfbml: true });

                /* All the events registered */
                FB.Event.subscribe('auth.login', function (response) {
                    // do something with response
                    login();
                });
                FB.Event.subscribe('auth.logout', function (response) {
                    // do something with response
                    logout();
                });

                FB.getLoginStatus(function (response) {
                    if (response.session) {
                        // logged in and connected user, someone you know
                        login();
                    }
                });
            };
            (function () {
                var e = document.createElement('script');
                e.type = 'text/javascript';
                e.src = document.location.protocol +
                    '//connect.facebook.net/en_US/all.js';
                e.async = true;
                document.getElementById('fb-root').appendChild(e);
            }());

            function login() {
                FB.api('/me', function (response) {
                    document.getElementById('login').style.display = "block";
                    document.getElementById('login').innerHTML = response.name + " succsessfully logged in!";
                });
            }
            function logout() {
                document.getElementById('login').style.display = "none";
            }

            //stream publish method
            function streamPublish(name, description, hrefTitle, hrefLink, userPrompt) {
                FB.ui(
                {
                    method: 'stream.publish',
                    message: '',
                    attachment: {
                        name: name,
                        caption: '',
                        description: (description),
                        href: hrefLink
                    },
                    action_links: [
                        { text: hrefTitle, href: hrefLink }
                    ],
                    user_prompt_message: userPrompt
                },
                function (response) {

                });

            }
            function showStream() {
                FB.api('/me', function (response) {
                    //console.log(response.id);
                    streamPublish(response.name, 'Thinkdiff.net contains geeky stuff', 'hrefTitle', 'http://thinkdiff.net', "Share thinkdiff.net");
                });
            }

            function share() {
                var share = {
                    method: 'stream.share',
                    u: 'http://thinkdiff.net/'
                };

                FB.ui(share, function (response) { console.log(response); });
            }

            function graphStreamPublish() {
                var body = 'Reading New Graph api & Javascript Base FBConnect Tutorial';
                FB.api('/me/feed', 'post', { message: body }, function (response) {
                    if (!response || response.error) {
                        alert('Error occured');
                    } else {
                        alert('Post ID: ' + response.id);
                    }
                });
            }

            function fqlQuery() {
                FB.api('/me', function (response) {
                    var query = FB.Data.query('select name, birthday,sex, pic_square from user where uid={0}', response.id);
                    query.wait(function (rows) {

                        document.getElementById('name').innerHTML =
                          'Your name: ' + rows[0].name + "<br />" +
                          'Sex: ' + rows[0].sex + "<br />"+
                          'Birthday: ' +rows[0].birthday + "<br />"+
                           
                          '<img src="' + rows[0].pic_square + '" alt="" height="130" width="130"/>' + "<br />";
                        

                        var uname = rows[0].name;
                        document.getElementById('<%= Hidden1.ClientID %>').value = uname;
                    });
                });
            }

           
        
    


            function setStatus() {
                status1 = document.getElementById('status').value;
                FB.api(
                  {
                      method: 'status.set',
                      status: status1
                  },
                  function (response) {
                      if (response == 0) {
                          alert('Your facebook status not updated. Give Status Update Permission.');
                      }
                      else {
                          alert('Your facebook status updated');
                      }
                  }
                );
            }
        </script>
 
        <h3 style="font-weight: 600; font-size: xx-large;">&nbsp; SkyyNet Print Server Login&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </h3>
    
    
    
    <form id="form2" runat="server">
 
        <p style="font-size: larger">
            
            
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
        <p><fb:login-button autologoutlink="true" data-size="xlarge" perms="email,user_birthday,status_update,publish_stream"></fb:login-button>
    </p>
 
                    </td>
                    <td class="auto-style5" style="font-size: larger">Step 1 - Login with a FaceBook account.</td>
                    <td>
                        <img alt="" class="auto-style6" src="pink-skull.gif" style="width: 199px; height: 120px" /></td>
                </tr>
                <tr>
                    <td class="auto-style8" style="vertical-align: top; font-size: larger;"><a href="#" onclick="fqlQuery(); return false;" style="font-size: larger">Verify FaceBook Login</a></td>
                    <td class="auto-style9" style="vertical-align: top; font-size: larger;">Step 2 - Verify if This is You</td>
                    <td class="auto-style10">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <img alt="" class="auto-style7" src="download.gif" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                </tr>
                <tr>
                    <td class="auto-style2">
 
        
        <div id="name"></div>
    
    
    
                    </td>
                    <td class="auto-style5" style="font-size: larger">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2" style="vertical-align: top">
                        <br />
        <asp:Button ID="Button1" runat="server" Text="Print Server" OnClientClick="JavaScriptFunction()" onclick="Button1_Click" Font-Bold="True" Font-Size="Large" Height="44px" Width="133px" />
                    </td>
                    <td class="auto-style5" style="font-size: larger; vertical-align: top;">Step 3 - If you are this person Click!</td>
                    <td>
                        <img class="auto-style3" src="printer.gif" /></td>
                </tr>
            </table>
        </p>
 
        
    <div>
        <asp:HiddenField ID="Hidden1" runat="server" />
        <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
    </div>
    </form>

    <table class="auto-style1">
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

    </body>
</html>
