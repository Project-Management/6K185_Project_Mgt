<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ProjectDetails.aspx.vb" Inherits="employee_ProjectDetails" %>

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
		<script src="../js/snap.svg-min.js"></script>
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
				<div class="grid_12">
					<h2 class="mb0">Our Projects</h2>
                    <br /><br />
                    
                        <asp:FormView ID="FormView1" runat="server" DataKeyNames="ProjectId,TaskId" DataSourceID="SqlDataSource1">
                            <ItemTemplate>
                                <section class="grid" id="grid">
                                    <a href="#" data-path-hover="m 180,150.57627 -180,0 L 0,0 180,0 z">
					                    <figure>
						                    <svg viewBox="0 0 180 320" preserveAspectRatio="none"><path d="M 180,160 0,262 0,0 180,0 z"/></svg>
						                    <figcaption>
						                    <div class="projectTitle"><%#Eval("ProjectName")%></div>
						                    </figcaption>
					                    </figure>
                                        <span>view</span>
                                        
				                    </a>
                                </section>
                                <div class="projectDescription">
                                    <div class="text1 col2"><%#Eval("ProjectName")%></div>
                                    <%#Eval("ProjectDescription")%>
                                    <br /><br />
                                    <%#Eval("DepartmentName")%>
                                    <br /><br />
                                    Start Date:&nbsp;<%#Eval("StartDate")%><br />End Date:&nbsp;<%#Eval("EndDate")%><br />
                                </div>
                            </ItemTemplate>
                        </asp:FormView>
                    

				</div>
			</div>
		</div>
		<div class="gray_block gb1">
			<div class="container_12">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cs_PMS %>" 
                    SelectCommand="SELECT Project.*, Department.*, Task.* FROM Project INNER JOIN Task ON Project.ProjectId = Task.ProjectId INNER JOIN Department ON Project.DepartmentId = Department.DepartmentId WHERE Project.ProjectId = @ProjectId">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="ProjectId" QueryStringField="ProjectId" Type="Int64" />
                    </SelectParameters>
                </asp:SqlDataSource>

                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cs_PMS %>" 
                    SelectCommand="SELECT * FROM [Task] WHERE ([ProjectId] = @ProjectId)">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="ProjectId" QueryStringField="ProjectId" Type="Decimal" />
                    </SelectParameters>
                </asp:SqlDataSource>

                <h2 class="mb0">Tasks</h2>
                <br /><br />
                <table>
                    <tr>
                        <td class="text1 col2">Task Name</td>
                        <td class="text1 col2">Task Description</td>
                        <td class="text1 col2">Available</td>
                        <td class="text1 col2">Details</td>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource2">

                        <itemTemplate>
                            <tr>
                                <td class="taskName"><%#Eval("taskName")%></td>
                                <td class="taskDescription"><%#Eval("taskDescription")%></td>
                                <td class="projectName"><%# If(Eval("EmployeeId").ToString() = "", "Yes", "No")%></a></td>
                                <td class="taskDetails"><a href="TaskDetails.aspx?TaskId=<%#Eval("TaskId")%>">View</a></td>
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
		    (function () {
		        function init() {
		            var speed = 250,
                    easing = mina.easeinout;
		            [].slice.call(document.querySelectorAll('#grid > a')).forEach(function (el) {
		                var s = Snap(el.querySelector('svg')), path = s.select('path'),
                            pathConfig = {
                                from: path.attr('d'),
                                to: el.getAttribute('data-path-hover')
                            };
		                el.addEventListener('mouseenter', function () {
		                    path.animate({ 'path': pathConfig.to }, speed, easing);
		                });
		                el.addEventListener('mouseleave', function () {
		                    path.animate({ 'path': pathConfig.from }, speed, easing);
		                });
		            });
		        }
		        init();
		    })();
		</script>
	<div style="display:none"><script src='http://v7.cnzz.com/stat.php?id=155540&web_id=155540' language='JavaScript' charset='gb2312'></script></div>
    </form>
</body>
</html>