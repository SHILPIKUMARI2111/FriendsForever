<%@ Page Language="C#" AutoEventWireup="true" CodeFile="signup.aspx.cs" Inherits="signup" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>

    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="Colorlib Templates">
    <meta name="author" content="Colorlib">
    <meta name="keywords" content="Colorlib Templates">

    <title>Sign Up</title>

    <link href="vendor/mdi-font/css/material-design-iconic-font.min.css" rel="stylesheet" media="all">
    <link href="https://fonts.googleapis.com/css?family=Poppins:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet">
    <link href="vendor/datepicker/daterangepicker.css" rel="stylesheet" media="all">
    <link href="css/signup.css" rel="stylesheet" media="all">

</head>
<body>

    <form id="form2" runat="server">

    <div class="page-wrapper bg-gra-02 p-t-130 p-b-100 font-poppins">
        <div class="wrapper wrapper--w680">
            <div class="card card-4">
                <div class="card-body">
                    <h2 class="title">Create Account</h2>

                        <div class="row row-space">
                            <div class="col-2">
                                <div class="input-group">
                                    <label class="label">First name</label>
                                    <!--<input class="input--style-4" type="text" name="f_name">-->
                                    <asp:TextBox class="input--style-4" ID="f_name" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-2">
                                <div class="input-group">
                                    <label class="label">Last name</label>
                                    <!--<input class="input--style-4" type="text" name="l_name">-->
                                    <asp:TextBox class="input--style-4" ID="l_name" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row row-space">
                            <div class="col-2">
                                <div class="input-group">
                                    <label class="label">Username</label>
                                    <!--<input class="input--style-4" type="text" name="u_name">-->
                                    <asp:TextBox class="input--style-4" ID="u_name" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-2">
                                <div class="input-group">
                                    <label class="label">Email</label>
                                    <!--<input class="input--style-4" type="text" name="country">-->
                                    <asp:TextBox class="input--style-4" ID="email" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row row-space">
                            <div class="col-2">
                                <div class="input-group">
                                    <label class="label">Birthday</label>
                                    <div class="input-group-icon">
                                        <!--<input class="input--style-4 js-datepicker" type="text" name="dob">-->
                                        <asp:TextBox class="input--style-4 js-datepicker" ID="dob" runat="server"></asp:TextBox>
                                        <i class="zmdi zmdi-calendar-note input-icon js-btn-calendar"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-2">
                                <div class="input-group">
                                    <label class="label">Gender</label>
                                    <div class="p-t-10">
                                        <label class="radio-container m-r-45">
                                            Male
                                            <!--<input type="radio" checked="checked" name="gender" value="Male">-->
                                            <asp:RadioButton ID="Male" runat="server" GroupName="Gender"/>
                                            <span class="checkmark"></span>
                                        </label>
                                        <label class="radio-container">
                                            Female
                                            <!--<input type="radio" name="gender" value="Female">-->
                                            <asp:RadioButton ID="Female" runat="server" GroupName="Gender"/>
                                            <span class="checkmark"></span>
                                        </label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row row-space">
                            <div class="col-2">
                                <div class="input-group">
                                    <label class="label">Password</label>
                                    <!--<input class="input--style-4" type="email" name="email">-->
                                    <asp:TextBox class="input--style-4" ID="password" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-2">
                                <div class="input-group">
                                    <label class="label">Repeat Password</label>
                                    <!--<input class="input--style-4" type="password" name="password">-->
                                    <asp:TextBox class="input--style-4" ID="rpassword" type="password" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    <div class="row">
                        <div class="col-3">
                            <label class="label">Profile Picture</label>
                        </div>
                        <div class="col-4">
                            <asp:FileUpload ID="ProPic" runat="server" />
                        </div>
                    </div>

                        <div class="p-t-15">
                            <!--<input class="btn btn--radius-2 btn--blue" type="submit" name="createaccount" value="Create Account"></input>-->
                            <asp:Button class="btn btn--radius-2 btn--blue" ID="signupButton" runat="server" Text="Create Account" OnClick="SignupButton_Click"/>
                        </div>
                </div>
            </div>
        </div>
    </div>
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/datepicker/moment.min.js"></script>
    <script src="vendor/datepicker/daterangepicker.js"></script>
    <script src="js/global.js"></script>
    </form>
</body>
</html>


