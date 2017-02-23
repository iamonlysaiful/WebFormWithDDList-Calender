using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    dbEntities1 db = new dbEntities1();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnDelete.Visible = false;
        btnEdit.Visible = false;
        btnCancel.Visible = false;
        refreshAll();
    }

    private void refreshAll()
    {

        var data = db.Doctors.Select(d => new { d.DoctorID, d.dName, d.dEmail, d.dScheduleDay, d.Department.DepartmentName, d.Room.RoomNo }).ToList();
        GridView1.DataSource = data;
        GridView1.DataBind();

        if (!IsPostBack)
        {

         
            
          
            populateDropdown();
        }
    }

    private void populateDropdown()
    {
        //Popolating Data From Foreign Key Table in DropDownlist

        var src = (from d in db.Departments
                   select new
                   {
                       d.DepartmentId,
                       d.DepartmentName
                   }).ToList();
        
        dlistDepartment.DataSource = src;
    
        dlistDepartment.DataTextField = "DepartmentName";
        dlistDepartment.DataValueField = "DepartmentId";
        dlistDepartment.DataBind();
        dlistDepartment.Items.Insert(0, "--Please Select--");

        var src1 = (from r in db.Rooms
                    select r).ToList();
  
        dListRoomNo.DataSource = src1;
     
        dListRoomNo.DataTextField = "RoomNo";
        dListRoomNo.DataValueField = "RoomId";
        dListRoomNo.DataBind();
        dListRoomNo.Items.Insert(0, "--Please Select--");

        //Popolating Data From Foreign Key Table in DropDownlist
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        try
        {
            Doctor d = new Doctor();
            d.DoctorID = Int32.Parse(txtDId.Text);
            d.dName = txtDName.Text;
            d.dEmail = txtEmail.Text;
            d.dScheduleDay = calSDay.SelectedDate.ToShortDateString();
            d.DepartmentId = Int32.Parse(dlistDepartment.SelectedValue);
            d.RoomId = Int32.Parse(dListRoomNo.SelectedValue);

            //Existing Record Checking Validation

            bool recordtExists = db.Doctors.Any(dn => dn.DoctorID.Equals(d.DoctorID));
            //Existing Record Checking Validation
            if (recordtExists)
            {
                refreshAll();
                Literal1.Text = "Data Existed Before!!!";

                btnDelete.Visible = false;
                btnEdit.Visible = false;
                btnCancel.Visible = false;
                btnSave.Visible = true;
                btnSearch.Visible = true;
                Clear();
            }
            else
            {
                db.Doctors.Add(d);
                db.SaveChanges();
                Clear();
                refreshAll();
                Literal1.Text = "Data Inserted Successfully!!!";

                btnDelete.Visible = false;
                btnEdit.Visible = false;
                btnCancel.Visible = false;
                btnSave.Visible = true;
                btnSearch.Visible = true;
            }
        }
        catch (Exception ex)
        {

            Literal1.Text = ex.Message;
        }


    }

    private void Clear()
    {
        txtDId.Text = "";
        txtDName.Text = "";
        txtEmail.Text = "";
        Literal2.Text = "";
        populateDropdown();
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            int idn = Int32.Parse(txtDId.Text);
            var data = (from d in db.Doctors
                        where d.DoctorID == idn
                        select d).FirstOrDefault();


            if (data != null)
            {
                txtDId.Text = data.DoctorID.ToString();
                txtDName.Text = data.dName;
                txtEmail.Text = data.dEmail;
                Literal2.Text = data.dScheduleDay;
                calSDay.SelectedDate = DateTime.Parse(data.dScheduleDay);
                dlistDepartment.SelectedValue = data.DepartmentId.ToString();
                dListRoomNo.SelectedValue = data.RoomId.ToString();
                Literal1.Text = "";
                btnDelete.Visible = true;
                btnEdit.Visible = true;
                btnSearch.Visible = true;
                btnSave.Visible = false;
                btnCancel.Visible = true;
            }
            else
            {
                Literal1.Text = "Data Not Found!!!";
                Clear();
                btnSearch.Visible = true;
                btnSave.Visible = true;
            }
        }
        catch (Exception ex1)
        {
            Literal1.Text = ex1.Message;
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

        int idn = Int32.Parse(txtDId.Text);

        var data = (from d in db.Doctors
                    where d.DoctorID == idn
                    select d).FirstOrDefault();

        if (data != null)
        {
            db.Doctors.Remove(data);
            db.SaveChanges();

            Clear();
            refreshAll();
            Literal1.Text = "Data Deleted Successfully!";
            btnSearch.Visible = true;
            btnSave.Visible = true;
        }
        else
        {
            Literal1.Text = "Data Not Found!!!";
            Clear();
            btnSearch.Visible = true;
            btnSave.Visible = true;
        }

    }

    protected void calSDay_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {

        }



    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        int idn = Int32.Parse(txtDId.Text);
        var data = (from d in db.Doctors
                    where d.DoctorID == idn
                    select d).FirstOrDefault();

        if (data != null)
        {
            data.DoctorID = Int32.Parse(txtDId.Text);
            data.dName = txtDName.Text;
            data.dEmail = txtEmail.Text;
            data.dScheduleDay = Literal2.Text;
            data.DepartmentId = Int32.Parse(dlistDepartment.SelectedValue);
            data.RoomId = Int32.Parse(dListRoomNo.SelectedValue);
            db.SaveChanges();
            Literal1.Text = "Data Edited Successfully!";
            refreshAll();
            Clear();

            btnDelete.Visible = false;
            btnEdit.Visible = false;
            btnSearch.Visible = true;
            btnSave.Visible = true;
            btnCancel.Visible = false;

        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnDelete.Visible = false;
        btnEdit.Visible = false;
        btnSearch.Visible = true;
        btnSave.Visible = true;
        btnCancel.Visible = false;

        Clear();
    }
    protected void calSDay_SelectionChanged(object sender, EventArgs e)
    {
        Literal2.Text = calSDay.SelectedDate.ToShortDateString();
        //btnEdit.Visible = true;
       btnCancel.Visible = true;
    }

   
}