<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
		<title>Home | Project Management System</title>
		<link rel="icon" href="images/icon.ico"/>
		<link rel="shortcut icon" href="images/icon.ico"/>
		<link rel="stylesheet" href="css/camera.css"/>
		<link rel="stylesheet" href="css/style.css"/>
		<script src="js/jquery.js"></script>
		<script src="js/jquery-migrate-1.1.1.js"></script>
		<script src="js/jquery.ui.totop.js"></script>
		<script src="js/jquery.easing.1.3.js"></script>
		<script src="js/camera.js"></script>
		<script>
		    $(document).ready(function () {
		        jQuery('#camera_wrap').camera({
		            loader: false,
		            pagination: true,
		            minHeight: '394',
		            thumbnails: false,
		            height: '480px',
		            caption: false,
		            navigation: false,
		            fx: 'mosaic'
		        });
		        $().UItoTop({ easingType: 'easeOutQuart' });
		    })
		</script>
         
	</head>
	<body class="page1">
        <form id="form1" runat="server">
		<header>
            <div class="status">
                <a href="./Default.aspx">Project Management System</a>
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
                                <li><a href="./employee/Search.aspx">Search</a></li>
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
								<li class="current bt-icon"><a href="./Default.aspx">Home</a></li>
								<li class="bt-icon"><a href="./About.aspx">About</a></li>
								<li class="bt-icon"><a href="./employee/Project.aspx">Projects</a></li>
								<li class="bt-icon"><a href="./Contact.aspx">Contacts</a></li>
							</ul>
						</nav>
						<div class="clear"></div>
					</div>
					<div class="clear"></div>
				</div>
			</div>
		</header>
		<div class="slider_wrapper">
			<div id="camera_wrap" class="">
				<div data-src="images/slide.jpg"></div>
				<div data-src="images/slide1.jpg"></div>
				<div data-src="images/slide2.jpg"></div>
                
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