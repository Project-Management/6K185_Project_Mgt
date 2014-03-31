<%@ Page Language="VB" AutoEventWireup="false" CodeFile="About.aspx.vb" Inherits="About" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
	    <title>About | Project Management System</title>
	    <link rel="icon" href="images/icon.ico"/>
	    <link rel="shortcut icon" href="images/icon.ico"/>
	    <link rel="stylesheet" href="css/style.css"/>
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
								<li class="bt-icon"><a href="./Default.aspx">Home</a></li>
								<li class="current bt-icon"><a href="./About.aspx">About</a></li>
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
<!--==============================Content=================================-->
		<div class="content">
			<div class="container_12">
				<div class="grid_4">
					<h2>Objective</h2>
					<img src="images/task.jpg" alt="" class="img_inner" />
					<div class="text1 col2">What is Project Management System?</div>
                    <p>This system is designed for helping companies better organize, moderate, and complete a project. We call it Project Management System.</p>			
                </div>

				<div class="grid_4">
					<h2>Functions</h2>
                    <div class="text1 col2">What this system can do for us?</div>
					<p>Basically, two main functions will be designed in our system.</p>
                    <p>First, employees can log into the system and find suitable projects corresponding their capabilities and time schedules. Each project will be assigned by a manager with limited employees to work on it.</p>
                    <p>Second, employees can track project process through the system. Employees may track what they did everyday chronologically, or track by different projects.</p>
                    <p>Through this system, a manager can assigned projects to employees online and let employees choose projects they are confident.</p>
                    <p>In addition, employees can track old projects when they are doing similar one. If an employees quit his project due to illness, another employee can track his project and finish remaining jobs.</p>
				</div>

				<div class="grid_4">
					<h2>Related Files</h2>
					<div class="text1 col2">Interested in our project and would like to know more?</div>
					<p>The files following may give you a better understanding on our system</p>
					<ul class="list">
                        <li><a href="#">Project Documentation</a></li>
                        <li><a href="documents/Architecture Diagram.pdf">Architecture Diagram</a></li>
						<li><a href="documents/Business Domain Model.pdf">Business Domain Model</a></li>
						<li><a href="documents/ER Model.pdf">ER Diagram</a></li>
						<li><a href="documents/Use Case Diagram.pdf">Use Case Diagram</a></li>
                        <li><a href="documents/User Story.pdf">User Story</a></li>
						<li><a href="documents/Wireframe.pdf">Wireframe</a></li>
						
					</ul>
					<p>In case you have any questions or comments, our staff is more than happy to assist you.</p>
                    <a href="./Contact.aspx" class="btn">Contact Us</a>
				</div>
			</div>
		</div>
		<div class="gray_block center">
			<div class="container_12">
				<div class="grid_12">
					<h3>Designers & Developers</h3>
				</div>
				<div class="grid_3">
					<div class="block3">
						<img src="images/zhaoyang.jpg" alt="" />
						<div class="text2"><a href="http://myweb.uiowa.edu/zhadai" target="_blank">Zhaoyang Dai</a></div>
						Web Developer & Data Analyst
					</div>
				</div>
				<div class="grid_3">
					<div class="block3 bd1">
						<img src="images/haoran.jpg" alt="" />
						<div class="text2"><a href="http://www.haoranwang.net" target="_blank">Haoran Wang</a></div>
						
					</div>
				</div>
				<div class="grid_3">
					<div class="block3 bd2">
						<img src="images/min.jpg" alt="" />
						<div class="text2"><a href="#">Min Yang</a></div>
						
					</div>
				</div>
				<div class="grid_3">
					<div class="block3 bd3">
						<img src="images/chang.jpg" alt="" />
						<div class="text2"><a href="#">Chang Shang</a></div>
						
					</div>
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