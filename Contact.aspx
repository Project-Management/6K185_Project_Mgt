<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Contact.aspx.vb" Inherits="Contact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
		<title>Contacts | Project Management System</title>
		<link rel="icon" href="images/icon.ico">
		<link rel="shortcut icon" href="images/icon.ico">
		<link rel="stylesheet" href="css/style.css">
		<script src="js/jquery.js"></script>
		<script src="js/jquery-migrate-1.1.1.js"></script>
		<script src="js/jquery.ui.totop.js"></script>
		<script src="js/jquery.easing.1.3.js"></script>
		<script>
		    $(document).ready(function () {
		        $().UItoTop({ easingType: 'easeOutQuart' });
		    })
		</script>
		
	</head>
	<body class="">
        <form id="form1" runat="server">
		<header>
            <div class="status">
                <a href= "./Default.aspx">Project Management System</a>
                <div class="profile">

                    <ul id="nav">
                        <li><a href="#">Status</a>
                            <ul>
                                <li><a href="./employee/Profile.aspx">Profile</a></li>
                                <li>
                                    <asp:LoginStatus ID="LoginStatus1" runat="server" LoginText="Sign In" LogoutText="Sign Out" />
                                </li>
                            </ul>
                        </li>
                        <li><a href="#">Admin</a>
                            <ul class="left">
                                <li><a href="./employer/AddNewEmployee.aspx">Register Staff</a></li>
                                <li><a href="./employer/AddNewProject.aspx">Release Project</a></li>
                                <li><a href="./employer/ViewAllEmployees.aspx">View All Staffs</a></li>
                                <li><a href="./employer/ViewAllProjects.aspx">View All Projects</a></li>
                            </ul>
                        </li>
                    </ul>

                </div>
            </div>
			<div class="container_12">
				<div class="grid_12">
					<div class="menu_block">
						<nav id="bt-menu" class="bt-menu">
							<a href="#" class="bt-menu-trigger"><span>Menu</span></a>
							<ul>
								<li class="bt-icon"><a href="./Default.aspx">Home</a></li>
								<li class="bt-icon"><a href="./About.aspx">About</a></li>
								<li class="bt-icon"><a href="./employee/Project.aspx">Projects</a></li>
								<li class="current bt-icon"><a href="./Contact.aspx">Contacts</a></li>
							</ul>
						</nav>
						<div class="clear"></div>
					</div>
					<div class="clear"></div>
				</div>
			</div>
		</header>
<!--==============================Content=================================-->
		<div class="content cont2">
			<div class="container_12">
				<div class="grid_12">
					<h2 class="mb0">Find Us</h2>
				</div>
			</div>
		</div>
		<div class="gray_block gb1">
			<div class="container_12">
				<div class="grid_12">
					<div class="map">
						<figure class="">
						    <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d1490.320345560203!2d-91.53532215833869!3d41.66350464441294!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x87e441f178969f6b%3A0x3f4fd5c31d76764f!2sHenry+B.+Tippie+College+of+Business!5e0!3m2!1sen!2sus!4v1394906778039"></iframe>
                        </figure>
					</div>
				</div>
				<div class="grid_4">
					<h2 class="head1">Address</h2>
					<div class="map">
					<address>
						<dl>
							<dt> Henry B. Tippie College of Business, <br />
								University of Iowa,<br />
								108 John Pappajohn Business Building, <br />
                                Iowa City, IA, 52242-1994
							</dt>
							<dd><span>Phone:</span>+1 319 335 0862</dd>
                            <dd><span>Fax:</span>+1 319 335 0860</dd>
                            <dd><span>Toll Free:</span>+1 800 553 4692</dd>
							<dd><span>E-mail:</span> <a href="mailto:tippie-business@uiowa.edu" class="col3">tippie-business@uiowa.edu</a></dd>
						</dl>
					</address>
					<p>Have any questions about Project Management System? Address to <span class="col3"><a href="About.aspx">About page</a></span>.</p>
					<p>24/7 support is available </p></div>
				</div>
				<div class="grid_8">
					<h2 class="head1">Contact Form</h2>
					<form id="form">
						<div class="success_wrapper">
							<div class="success-message">Contact form submitted</div>
						</div>
						<label class="name">
                            <asp:TextBox ID="TBName" runat="server" placeholder="Name:" Width="184px" Height="24px" ForeColor="#8C8989" BackColor="#FCFCFC" BorderStyle="Ridge" Font-Names="Arial" CssClass="textbox"></asp:TextBox>
						</label>
						<label class="email">
							<asp:TextBox ID="TBMail" runat="server" placeholder="E-mail:" Width="184px" Height="24px" ForeColor="#8C8989" BackColor="#FCFCFC" BorderStyle="Ridge" Font-Names="Arial" CssClass="textbox"></asp:TextBox>
						</label>
						<label class="phone">
							<asp:TextBox ID="TBPhone" runat="server" placeholder="Phone:" Width="184px" Height="24px" ForeColor="#8C8989" BackColor="#FCFCFC" BorderStyle="Ridge" Font-Names="Arial" CssClass="textbox"></asp:TextBox>
						</label>
                        <br /><br />
						<label class="message">
							<asp:TextBox ID="TBMessage" runat="server" placeholder="Message:" Width="579px" Height="220px" ForeColor="#8C8989" BackColor="#FCFCFC" BorderStyle="Ridge" TextMode="MultiLine" Font-Names="Arial" CssClass="textbox"></asp:TextBox>
						</label>
						<div>
							<div class="clear"></div>
							<div class="btns">
                                <asp:LinkButton ID="clear" runat="server"  class="btn" style="cursor:pointer" >clear</asp:LinkButton>
								<asp:LinkButton ID="submit" runat="server"  class="btn" style="cursor:pointer" >submit</asp:LinkButton>
							</div>
						</div>
					</form>
				</div>
			</div>
		</div>
<!--==============================footer=================================-->
		<footer>
			<div class="container_12">
				<div class="grid_12">
					<div class="socials">
						<a href="#" class="fa fa-facebook"></a>
						<a href="#" class="fa fa-twitter"></a>
						<a href="#" class="fa fa-google-plus"></a>
					</div>
					<div class="clear"></div>
					<div class="copy">
						Copyright &copy; 2014 CapStone Project - the University of Iowa
					</div>
				</div>
			</div>
		</footer>
		<script>
		    $(document).ready(function () {
		        $(".bt-menu-trigger").toggle(
                    function () {
                        $('.bt-menu').addClass('bt-menu-open');
                    },
                    function () {
                        $('.bt-menu').removeClass('bt-menu-open');
                    }
                );
		    });
		</script>
	<div style="display:none"><script src='http://v7.cnzz.com/stat.php?id=155540&web_id=155540' language='JavaScript' charset='gb2312'></script></div>
    </form>
</body>
</html>