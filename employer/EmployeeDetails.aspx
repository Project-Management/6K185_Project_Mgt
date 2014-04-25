<%@ Page Language="VB" AutoEventWireup="false" CodeFile="EmployeeDetails.aspx.vb" Inherits="employer_EmployeeDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8"/>
		<title>Profile | Project Management System</title>
		<link rel="icon" href="../images/icon.ico"/>
		<link rel="shortcut icon" href="../images/icon.ico"/>
		<link rel="stylesheet" href="../css/style.css"/>
		<script src="../js/jquery.js"></script>
		<script src="../js/jquery-migrate-1.1.1.js"></script>
		<script src="../js/jquery.ui.totop.js"></script>
		<script src="../js/jquery.easing.1.3.js"></script>
        <script src="//netdna.bootstrapcdn.com/bootstrap/3.0.2/js/bootstrap.min.js" type="text/javascript"></script>
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
                <asp:FormView ID="FormView1" runat="server" DataSourceID="SqlDataSource1">
                    <EmptyDataTemplate>
                        <div class="page-header">
                            <h2>Sorry No Data Found</h2>
                        </div>
                    </EmptyDataTemplate>

                    <ItemTemplate>

                        <div class="grid_12">
					        <h2 class="mb0"><a href="ViewAllEmployees.aspx">Staff Information</a></h2>
				        </div>
                        <br /><br /><br /><br /><br /><br />
                        <div class="profilePicture">
                            <div class="block3">
                                <asp:Image ID="ImgProfile" runat="server" src='<%# Eval ("Photo", "../images/employee/{0}") %>' />
                            </div>
                        </div>
                        <div class="filterBar">
                            <ul class="nav nav-pills">
                                <li><a href="#basic" data-toggle="tab">Basic Profile</a></li>
                                <li><a href="#contact" data-toggle="tab">Contact Information</a></li>
                                <li><a href="#employee" data-toggle="tab">Position Status</a></li>
                            </ul>
                        </div>
                        <div class="profileDescription">
                            <div class="row">
                                <div class="col-md-12">
                                    
                                    <div class="tab-content">
                                        <div class="tab-pane active" id="basic">
                                            <div class="row">
                                                <strong>Name:</strong> <%# Eval("FirstName")%> <%# Eval("MiddleName")%> <%# Eval("LastName")%><br />
                                                <strong>Birth Date:</strong> <%# Eval("Birthday")%><br />
                                                <strong>Driver's License:</strong> <%# Eval("DriverLicense")%><br />
                                                <strong>Social Security:</strong> <%# Eval("SSN")%><br />
                                                <strong>Marital Status:</strong> <%# Eval("MaritalStatus")%><br />
                                            </div>
                                            
                                        </div>
                                        <div class="tab-pane" id="contact">
                                            <div class="row">
                                                <strong>Email:</strong> <%# Eval("Email")%><br />
                                                <strong>Home Phone:</strong> <%# Eval("HomePhone")%><br />
                                                <strong>Mobile Phone:</strong> <%# Eval("MobilePhone")%><br />
                                            </div>
                                            <div class="row">
                                                <strong>Address:</strong> <%# Eval("Address")%>, <%# Eval("City")%>, <%# Eval("State")%>, <%# Eval("Zip")%><br />
                                            </div>
                                        </div>
                                        <div class="tab-pane" id="employee">
                                            <div class="row">
                                                <strong>Hire Date:</strong> <%# Eval("HireDate")%><br />
                                                <strong>Employer Name:</strong> <%# Eval("EmployerName")%><br />
                                                <strong>Department:</strong> <%# Eval("DepartmentName")%><br />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <a href="EditProfile.aspx?UserId=<%#Eval("UserId")%>"  class="btn" style="cursor:pointer" >Edit Profile</a>
                            </div>

                        </div>
                    </ItemTemplate>

                </asp:FormView>
			</div>
		</div>
		<div class="gray_block gb1">
			<div class="container_12">
                <h2 class="mb0">Task in Progress</h2>
                <br /><br />


                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cs_PMS %>" 
                    SelectCommand="SELECT aspnet_Users.UserName, StaffInfo.*, Department.* FROM aspnet_Users INNER JOIN StaffInfo ON aspnet_Users.UserId = StaffInfo.UserId INNER JOIN Department ON StaffInfo.DepartmentId = Department.DepartmentId WHERE (aspnet_Users.UserId = @UserId)">
                    <selectparameters>
		                <asp:QueryStringParameter Name="UserId" QueryStringField="UserId" Type="String" />
	                </selectparameters>
                </asp:SqlDataSource>

                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cs_PMS %>" 
                    SelectCommand="SELECT Task.*, Project.* FROM Task INNER JOIN Project ON Task.ProjectId = Project.ProjectId WHERE ([EmployeeId] = @UserId)">
                    <selectparameters>
		                <asp:QueryStringParameter Name="UserId" QueryStringField="UserId" Type="String" />
	                </selectparameters>
                </asp:SqlDataSource>

                <table>
                    <tr>
                        <td class="text1 col2">Task Name</td>
                        <td class="text1 col2">Task Description</td>
                        <td class="text1 col2">Project Name</td>
                        <td class="text1 col2">Details</td>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource2">

                        <itemTemplate>
                        <tr>
                            <td class="taskName"><%#Eval("taskName")%></td>
                            <td class="taskDescription"><%#Eval("taskDescription")%></td>
                            <td class="projectName"><a href="ProjectDetails.aspx?ProjectId=<%#Eval("ProjectId")%>"><%#Eval("ProjectName")%></a></td>
                            <td class="taskDetails"><a href="../Employee/TaskDetails.aspx?TaskId=<%#Eval("TaskId")%>">View</a></td>
                        </tr>
                        
                        </itemTemplate>
                    </asp:Repeater>
                </table>

                <div class="clear"></div>
					
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