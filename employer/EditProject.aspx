<%@ Page Language="VB" AutoEventWireup="false" CodeFile="EditProject.aspx.vb" Inherits="employer_EditProject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8"/>
		<title>Edit | Project Management System</title>
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
				
                <div id="addInfo">
                    <div class="addInfoBox">
                        <table>

                            <tr>
                                <td align="right" class="addInfoText">Project Name:</td> <td align="left" class="auto-style3">
                                    <asp:TextBox ID="tb_ProjectName" runat="server" Columns="50" CssClass="addInfoTextbox"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_ProjectName" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td align="right" class="addInfoText">Department:</td> <td align="left" class="auto-style3">
                                    <asp:TextBox ID="tb_Department" runat="server" Columns="50" CssClass="addInfoTextbox" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                            
                            <tr>
                                <td align="right" class="addInfoText">Start Date(MM/DD/YY):</td> <td align="left" class="auto-style3">
                                    <asp:TextBox ID="tb_StartDate" runat="server" Columns="50" CssClass="addInfoTextbox" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td align="right" class="addInfoText">End Date(MM/DD/YY):</td> <td align="left" class="auto-style3">
                                    <asp:DropDownList ID="ddlMonth" runat="server" CssClass="dropdown"/><asp:DropDownList ID="ddlDay" runat="server" CssClass="dropdownFollow"/><asp:DropDownList ID="ddlYear" runat="server" CssClass="dropdownFollow"/>
                                </td>
                            </tr>

                            <tr>
                                <td align="right" class="addInfoText">Project Description:</td> <td align="left" class="auto-style3">
                                    <asp:TextBox ID="tb_Description" runat="server" Columns="50" CssClass="addInfoDescriptionTextbox" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tb_Description" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td align="left"><asp:LinkButton ID="Delete" runat="server" CssClass="btn">Delete</asp:LinkButton></td>
                                <td align="right">
                                    <asp:LinkButton ID="Cancel" runat="server" CssClass="btn">Cancel</asp:LinkButton>
                                    <asp:LinkButton ID="Update" runat="server" CssClass="btn">Update</asp:LinkButton>

                                </td>
                            </tr>
                        </table>

                    </div>
                </div>
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
