<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DeleteStaff.aspx.vb" Inherits="employer_Delete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8"/>
		<title>Delete | Project Management System</title>
		<link rel="icon" href="../images/icon.ico"/>
		<link rel="shortcut icon" href="../images/icon.ico"/>
		<link rel="stylesheet" href="../css/style.css"/>
		<script src="../js/jquery.js"></script>
		<script src="../js/jquery-migrate-1.1.1.js"></script>
		<script src="../js/jquery.ui.totop.js"></script>
		<script src="../js/jquery.easing.1.3.js"></script>
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
                <a href="../Default.aspx">Project Management System</a>
                <div class="profile">

                    <ul id="nav">
                        <li><a href="#">Status</a>
                            <ul>
                                <li><a href="../employee/Profile.aspx">Profile</a></li>
                                <li>
                                    <asp:LoginStatus ID="LoginStatus1" runat="server" LoginText="Sign In" LogoutText="Sign Out" />
                                </li>
                            </ul>
                        </li>
                        <li><a href="#">Admin</a>
                            <ul class="left">
                                <li><a href="../employer/AddNewEmployee.aspx">Register Staff</a></li>
                                <li><a href="../employer/AddNewProject.aspx">Release Project</a></li>
                                <li><a href="../employer/ViewAllEmployees.aspx">View All Staffs</a></li>
                                <li><a href="../employer/ViewAllProjects.aspx">View All Projects</a></li>
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
								<li class="bt-icon"><a href="../Default.aspx">Home</a></li>
								<li class="bt-icon"><a href="../About.aspx">About</a></li>
								<li class="current bt-icon"><a href="../employee/Project.aspx">Projects</a></li>
								<li class="bt-icon"><a href="../Contact.aspx">Contacts</a></li>
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
                <div id="delete">
                    <div class="autobox">
                        <h2>Delete Message</h2>
                        <p>Are you sure you want to delete the following user?</p>


                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cs_PMS %>" 
                            SelectCommand="SELECT aspnet_Users.UserName, StaffInfo.*, Department.* FROM aspnet_Users INNER JOIN StaffInfo ON aspnet_Users.UserId = StaffInfo.UserId INNER JOIN Department ON StaffInfo.DepartmentId = Department.DepartmentId WHERE (aspnet_Users.UserId = @UserId)">
                            <selectparameters>
		                        <asp:QueryStringParameter Name="UserId" QueryStringField="UserId" Type="String" />
	                        </selectparameters>
                        </asp:SqlDataSource>



                        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
                            <itemTemplate>

                                <div class="profilePicture">
                                    <div class="block3">
                                        <asp:Image ID="ImgProfile" runat="server" src='<%# Eval ("Photo", "../images/employee/{0}") %>' />
                                        <br />
                                        <div class="text2"><a href="./EmployeeDetails.aspx?UserId=<%#Eval("UserId")%>" ><%#Eval("FirstName")%> <%#Eval("MiddleName")%> <%#Eval("LastName")%></a></div>
                                    </div>
                                </div>

                            </itemTemplate>
                        </asp:Repeater>
                        <div class="deleteBtn">
                            <asp:LinkButton ID="No" runat="server" CssClass="btn">No</asp:LinkButton>
                            <asp:LinkButton ID="Yes" runat="server" CssClass="btn">Yes</asp:LinkButton>
                        </div>
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
		        $('.responsive').on('click', '.close', function () {
		            $('.close').remove();
		            bgColor = $('.active .card-front').css('background-color');
		            $('.responsive').removeClass(effect);
		            $('.all-content').hide();
		            $('.content li').removeClass('active').show().css({
		                'border-bottom': '1px solid #2c2c2c',
		                'border-left': '1px solid #2c2c2c'
		            });
		            $('.card-front, .card-back').show();
		            $('.content').css('background-color', bgColor);
		        });
		    });
		</script>
	<div style="display:none"><script src='http://v7.cnzz.com/stat.php?id=155540&web_id=155540' language='JavaScript' charset='gb2312'></script></div>
    </form>
</body>
</html>