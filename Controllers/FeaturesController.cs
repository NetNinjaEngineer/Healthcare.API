using Healthcare.API.Data;
using Healthcare.API.Entities.Procedures;
using Healthcare.API.Entities.Views;
using HealthCareAPI.Models.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCareAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FeaturesController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;

    [HttpGet("GetMedicinesWithDosagesAndSuppliers")]
    public async Task<IActionResult> GetMedicinesWithDosagesAndSuppliers()
    {
        return Ok(await _context.GetMedicinesWithDosagesAndSuppliers.ToListAsync());
    }

    [HttpGet("GetBirthdayCelebrations")]
    public async Task<IActionResult> GetBirthdayCelebrations()
    {
        return Ok(await _context.BirthdayCelebrations.ToListAsync());
    }

    [HttpGet("GetCurrentAppointments")]
    public async Task<IActionResult> GetCurrentAppointments()
    {
        return Ok(await _context.CurrentAppointments.ToListAsync());
    }

    [HttpGet("GetExpiringMedicines")]
    public async Task<IActionResult> GetExpiringMedicines()
    {
        return Ok(await _context.ExpiringMedicines.ToListAsync());
    }

    [HttpGet("GetAgesForHiredEmployees")]
    public async Task<IActionResult> GetAgesForHiredEmployees()
    {
        return Ok(await _context.GetAgesForHiredEmployees.ToListAsync());
    }

    [HttpGet("GetEmployeesWithDepartments")]
    public async Task<IActionResult> GetEmployeesWithDepartments()
    {
        return Ok(await _context.GetEmployeesWithDepartments.ToListAsync());
    }

    [HttpGet("GetMedicinesWithDosages")]
    public async Task<IActionResult> GetMedicinesWithDosages()
    {
        return Ok(await _context.GetMedicinesWithDosages.ToListAsync());
    }

    [HttpGet("GetMinAndMaxQuantityForMedicines")]
    public async Task<IActionResult> GetMinAndMaxQuantityForMedicine()
    {
        return Ok(await _context.GetMinAndMaxQuantityForMedicines.ToListAsync());
    }


    [HttpGet("GetMinAndMaxUnitPriceForMedicines")]
    public async Task<IActionResult> GetMinAndMaxUnitPriceForMedicines()
    {
        return Ok(await _context.GetMinAndMaxUnitPriceForMedicines.ToListAsync());
    }

    [HttpGet("GetPaidAppointments")]
    public async Task<IActionResult> GetPaidAppointments()
    {
        return Ok(await _context.GetPaidAppointments.ToListAsync());
    }

    [HttpGet("GetPateints")]
    public async Task<IActionResult> GetPateints()
    {
        return Ok(await _context.GetPateints.ToListAsync());
    }

    [HttpGet("GetPatientsWithAppointments")]
    public async Task<IActionResult> GetPatientsWithAppointments()
    {
        return Ok(await _context.GetPatientsWithAppointments.ToListAsync());
    }

    [HttpGet("GetSuppliersWithMedicinesProvided")]
    public async Task<IActionResult> GetSuppliersWithMedicinesProvided()
    {
        return Ok(await _context.GetSuppliersWithMedicinesProvideds.ToListAsync());
    }

    [HttpGet("GetVIPSuppliersWithMedicinesProvided")]
    public async Task<IActionResult> GetVIPSuppliersWithMedicinesProvided()
    {
        return Ok(await _context.GetVipsuppliersWithMedicinesProvideds.ToListAsync());
    }

    [HttpGet("LowStockMedicines")]
    public async Task<IActionResult> LowStockMedicines()
    {
        return Ok(await _context.LowStockMedicines.ToListAsync());
    }


    [HttpGet("MedicineInfos")]
    public async Task<IActionResult> MedicineInfos()
    {
        return Ok(await _context.MedicineInfos.ToListAsync());
    }

    [HttpGet("MedicineStocks")]
    public async Task<IActionResult> MedicineStocks()
    {
        return Ok(await _context.MedicineStocks.ToListAsync());
    }


    [HttpGet("OutOfStockMedicines")]
    public async Task<IActionResult> OutOfStockMedicines()
    {
        return Ok(await _context.OutOfStockMedicines.ToListAsync());
    }

    [HttpGet("PatientsWithCheckupCosts")]
    public async Task<IActionResult> PatientsWithCheckupCosts()
    {
        return Ok(await _context.PatientsWithCheckupCosts.ToListAsync());
    }


    [HttpGet("ReorderMedicines")]
    public async Task<IActionResult> ReorderMedicines()
    {
        return Ok(await _context.ReorderMedicines.ToListAsync());
    }

    [HttpGet("ShowPatientPrescriptions")]
    public async Task<IActionResult> ShowPatientPrescriptions()
    {
        return Ok(await _context.ShowPatientPrescriptions.ToListAsync());
    }

    [HttpGet("ShowSchedules")]
    public async Task<IActionResult> ShowSchedules()
    {
        return Ok(await _context.ShowSchedules.ToListAsync());
    }

    [HttpPost("PaginateShowSchedules")]
    public async Task<IActionResult> PaginateShowSchedules([FromBody] int page = 1)
    {
        var query = await _context.ShowSchedules.ToListAsync();
        var result = query.Skip((page - 1) * 10).Take(10);

        return Ok(result);
    }

    [HttpGet("SupplierPerformances")]
    public async Task<IActionResult> SupplierPerformances()
    {
        return Ok(await _context.SupplierPerformances.ToListAsync());
    }

    [HttpGet("TopSalaryEmployees")]
    public async Task<IActionResult> TopSalaryEmployees()
    {
        return Ok(await _context.TopSalaryEmployees.ToListAsync());
    }

    [HttpGet("UpcomingAppointments")]
    public async Task<IActionResult> UpcomingAppointments()
    {
        return Ok(await _context.UpcomingAppointments.ToListAsync());
    }

    [HttpPost("CreateAppointment")]
    public async Task<IActionResult> CreateAppointmentAsync([FromBody] AddAppointment appointment)
    {
        var employee = await _context.Employees.SingleOrDefaultAsync(x =>
            x.EmployeeId == appointment.EmployeeId);

        if (!employee!.JobTitle.ToLower().Equals("Doctor".ToLower()))
            return BadRequest("Invalid employee");

        if (!(appointment.Gender!.ToLower().Equals("Male".ToLower()) || appointment.Gender.ToLower().Equals("Female".ToLower())))
            return BadRequest("Gender must be male or female");


        var result = await _context.ExecuteAddAppointmentAsync(appointment.EmployeeId,
            appointment.FirstName,
            appointment.LastName,
            appointment.Gender,
            appointment.Phone,
            appointment.Email
        );

        return Ok($"Appointment  created successfully. Rows affected: {result}");
    }

    [HttpPost("CreateDepartment")]
    public async Task<IActionResult> CreateDepartmentAsync([FromQuery] AddDepartment department)
    {
        await _context.ExecuteAddDepartmentAsync(department.DepartmentName,
            department.DepartmentCost);

        return Ok(department);
    }

    [HttpPost("AssignEmployeeToDepartment")]
    public async Task<IActionResult> AssignEmployeeToDepartmentAsync(
        [FromQuery] AddEmployeeToDepartmentModel model)
    {
        bool validDept = await _context.Departments.AnyAsync(x =>
            x.DepartmentId == model.DepartmentId);

        bool validGender = model.Gender!.ToLower().Equals("male") ||
            model.Gender.ToLower().Equals("Female");

        if (validDept && validGender)
            await _context.ExecuteAddEmployeeToDepartmentAsync(
                model.DepartmentId, model.FirstName, model.LastName, model.Gender,
                model.JobTitle, model.Phone, model.Salary, model.DateOfBirth);
        else
            return BadRequest("Invalid Gender or department !!");

        return Ok(model);
    }

    [HttpGet("GetEmployeeSchedules")]
    public ActionResult<IQueryable<EmployeeScheduleView>> GetEmployeeSchedules()
    {
        var query = from employee in _context.Employees
                    join employeeSchedule in _context.EmployeeSchedules
                    on employee.EmployeeId equals employeeSchedule.EmployeeId
                    group new { employee, employeeSchedule } by new { employee.FirstName, employee.LastName, employee.JobTitle } into grouped
                    select new EmployeeScheduleView
                    {
                        EmployeeName = grouped.Key.FirstName + " " + grouped.Key.LastName,
                        Days = string.Join(", ", grouped.Select(es => GetDayOfWeekAbbreviation(es.employeeSchedule.DayOfWeek))),
                        Schedule = string.Join(", ", grouped.Select(es => $"{es.employeeSchedule.StartTime.ToString("hh\\:mm")} - {es.employeeSchedule.EndTime.ToString("hh\\:mm")}")),
                        JobTitle = grouped.Key.JobTitle
                    };

        return Ok(query);
    }

    private static string GetDayOfWeekAbbreviation(int dayOfWeek)
    {
        return Enum.GetName(typeof(DayOfWeek), dayOfWeek).Substring(0, 3).ToUpper();
    }

    [HttpGet("PaginateGetEmployeeSchedules")]
    public ActionResult<IQueryable<EmployeeScheduleView>> PaginateGetEmployeeSchedules([FromHeader] int page = 1)
    {
        var query = from employee in _context.Employees
                    join employeeSchedule in _context.EmployeeSchedules
                    on employee.EmployeeId equals employeeSchedule.EmployeeId
                    group new { employee, employeeSchedule } by new { employee.FirstName, employee.LastName, employee.JobTitle } into grouped
                    select new EmployeeScheduleView
                    {
                        EmployeeName = grouped.Key.FirstName + " " + grouped.Key.LastName,
                        Days = string.Join(", ", grouped.Select(es => GetDayOfWeekAbbreviation(es.employeeSchedule.DayOfWeek))),
                        Schedule = string.Join(", ", grouped.Select(es => $"{es.employeeSchedule.StartTime.ToString("hh\\:mm")} - {es.employeeSchedule.EndTime.ToString("hh\\:mm")}")),
                        JobTitle = grouped.Key.JobTitle
                    };

        var paginatedResult = query.Skip((page - 1) * 10).Take(10);

        return Ok(paginatedResult);
    }


    [HttpGet("PaginateEmployeeSchedules")]
    public ActionResult<IQueryable<EmployeeScheduleView>> PaginateEmployeeSchedules(int page = 1, int size = 10)
    {
        var query = from employee in _context.Employees
                    join employeeSchedule in _context.EmployeeSchedules
                    on employee.EmployeeId equals employeeSchedule.EmployeeId
                    group new { employee, employeeSchedule } by new { employee.FirstName, employee.LastName } into grouped
                    select new EmployeeScheduleView
                    {
                        EmployeeName = grouped.Key.FirstName + " " + grouped.Key.LastName,
                        Days = string.Join(", ", grouped.Select(es => GetDayOfWeekAbbreviation(es.employeeSchedule.DayOfWeek))),
                        Schedule = string.Join(", ", grouped.Select(es => $"{es.employeeSchedule.StartTime.ToString("hh\\:mm")} - {es.employeeSchedule.EndTime.ToString("hh\\:mm")}"))
                    };

        var result = query.Skip((page - 1) * size).Take(size);

        return Ok(result);
    }

    [HttpGet("GetTotalCheckupCostForDepartments")]
    public ActionResult<IQueryable<TotalCheckupCostView>> GetTotalCheckupCostForDepartments()
    {
        var query = _context.Departments
            .Join(_context.Employees, department => department.DepartmentId, employee => employee.DepartmentId, (department, employee) => new { employee, department })
            .Join(_context.Appointments, combined => combined.employee.EmployeeId, appointment => appointment.EmployeeId, (combined, appointment) => new { combined.department, appointment })
            .Where(entry => entry.appointment.Paid.ToLower() == "paid")
            .GroupBy(entry => entry.department.DepartmentName)
            .Select(grouped => new TotalCheckupCostView
            {
                DepartmentName = grouped.Key,
                TotalAppointments = grouped.Count(),
                TotalCost = grouped.Sum(entry => entry.department.DepartmentCost)
            });

        return Ok(query);
    }

    [HttpGet("GetPatientPrescriptionHistory")]
    public ActionResult<IQueryable<PatientPrescriptionHistoryView>> GetPatientPrescriptionHistory()
    {
        var query = from patient in _context.Patients
                    join prescription in _context.Prescriptions
                    on patient.PatientId equals prescription.PatientId
                    join patientPrescription in _context.PatientsPrescriptions
                    on prescription.PrescriptionId equals patientPrescription.PrescriptionId
                    group new { patient, prescription, patientPrescription } by new { patient.FirstName, patient.LastName, prescription.Diagnosis } into grouped
                    select new PatientPrescriptionHistoryView
                    {
                        PatientName = string.Concat(grouped.Key.FirstName, ' ', grouped.Key.LastName),
                        Diagnosis = grouped.Key.Diagnosis,
                        PrescribedMedicines = string.Join(", ", grouped.Select(entry => entry.patientPrescription.MedicineName))
                    };

        return Ok(query);
    }

    [HttpGet("Test")]
    public IActionResult GetData()
    {
        var query = from patient in _context.Patients
                    join prescription in _context.Prescriptions
                    on patient.PatientId equals prescription.PatientId
                    join patientPrescription in _context.PatientsPrescriptions
                    on prescription.PrescriptionId equals patientPrescription.PrescriptionId
                    group new { patient, prescription, patientPrescription } by new { patient.FirstName, patient.LastName, prescription.Diagnosis } into grouped
                    select new
                    {
                        Patient = string.Concat(grouped.Key.FirstName, " ", grouped.Key.LastName),
                        Medicines = string.Join(", ", grouped.Select(x => x.patientPrescription.MedicineName))
                    };

        return Ok(query);
    }

    [HttpGet("GetPatientAppointmentHistory")]
    public ActionResult<IQueryable<PatientAppointmentHistoryView>> GetPatientAppointmentHistory()
    {
        var query = from patient in _context.Patients
                    join appointment in _context.Appointments
                    on patient.PatientId equals appointment.PatientId
                    group new { patient, appointment } by new { patient.FirstName, patient.LastName } into grouped
                    select new PatientAppointmentHistoryView
                    {
                        PatientName = string.Concat(grouped.Key.FirstName, ' ', grouped.Key.LastName),
                        TotalAppointments = grouped.Count(),
                        FirstAppointment = grouped.Min(entry => entry.appointment.AppointmentDate),
                        LastAppointment = grouped.Max(entry => entry.appointment.AppointmentDate)
                    };

        var query2 = _context.Patients
            .GroupJoin(_context.Appointments, patient => patient.PatientId, appointment => appointment.PatientId,
                (patient, appointments) => new { patient, appointments })
            .SelectMany(
                x => x.appointments.DefaultIfEmpty(),
                (x, appointment) => new { x.patient, appointment })
            .GroupBy(x => new { x.patient.FirstName, x.patient.LastName },
                (key, group) => new PatientAppointmentHistoryView
                {
                    PatientName = key.FirstName + ' ' + key.LastName,
                    TotalAppointments = group.Count(),
                    FirstAppointment = group.Min(x => x.appointment.AppointmentDate),
                    LastAppointment = group.Max(x => x.appointment.AppointmentDate)
                });


        return Ok(query);
    }

    [HttpGet("GetTotalAppointmentsForDepartments")]
    public ActionResult<IQueryable<AppointmentsForDepartmentsView>> GetTotalAppointmentsForDepartments()
    {
        var query = _context.Departments
            .Join(_context.Employees, department => department.DepartmentId, employee => employee.DepartmentId,
                (department, employee) => new { department, employee })
            .Join(_context.Appointments, combined => combined.employee.EmployeeId,
                appointment => appointment.EmployeeId, (combined, appointment) => new { combined.department, appointment })
            .GroupBy(entry => entry.department.DepartmentName)
            .Select(x => new AppointmentsForDepartmentsView
            {
                DepartmentName = x.Key,
                TotalAppointments = x.Count()
            });

        var query2 = from department in _context.Departments
                     join employee in _context.Employees
                     on department.DepartmentId equals employee.DepartmentId
                     join appointment in _context.Appointments
                     on employee.EmployeeId equals appointment.EmployeeId
                     group new { department, employee, appointment } by department.DepartmentName into grouped
                     select new
                     {
                         Department = grouped.Key,
                         TotalAppointments = grouped.Count()
                     };


        return Ok(query);
    }

    [HttpGet("GetEmployeePerformanceSummary")]
    public ActionResult<IQueryable<EmployeePerformanceSummaryView>> GetEmployeePerformanceSummary()
    {
        var query = from appointment in _context.Appointments
                    join employee in _context.Employees
                    on appointment.EmployeeId equals employee.EmployeeId
                    where employee.JobTitle.ToLower().Equals("doctor")
                    group new { appointment, employee } by new { employee.JobTitle, employee.FirstName, employee.LastName } into grouped
                    select new EmployeePerformanceSummaryView
                    {
                        Employee = string.Concat(grouped.Key.FirstName, ' ', grouped.Key.LastName),
                        JobTitle = grouped.Key.JobTitle,
                        TotalAppointments = grouped.Count()
                    };

        return Ok(query);
    }

    [HttpGet("CalculateTotalCheckupCostsPaid")]
    public async Task<IActionResult> CalculateTotalCheckupCostsPaid()
    {
        var total = await _context.Departments
           .Join(_context.Employees, department => department.DepartmentId, employee => employee.DepartmentId, (department, employee) => new { employee, department })
           .Join(_context.Appointments, combined => combined.employee.EmployeeId, appointment => appointment.EmployeeId, (combined, appointment) => new { combined.department, appointment })
           .Where(entry => entry.appointment.Paid.ToLower() == "paid")
           .GroupBy(entry => entry.department.DepartmentName)
           .Select(grouped => new TotalCheckupCostView
           {
               DepartmentName = grouped.Key,
               TotalAppointments = grouped.Count(),
               TotalCost = grouped.Sum(entry => entry.department.DepartmentCost)
           })
               .SumAsync(x => x.TotalCost);

        return Ok(total);
    }

    [HttpGet("GetAppointmentFor")]
    public IActionResult GetAppointmentForAsync([FromQuery] string fullName)
    {
        var query = from appointment in _context.Appointments
                    join employee in _context.Employees
                    on appointment.EmployeeId equals employee.EmployeeId
                    where employee.JobTitle.ToLower() == "doctor"
                    join patient in _context.Patients
                    on appointment.PatientId equals patient.PatientId
                    join department in _context.Departments
                    on employee.DepartmentId equals department.DepartmentId
                    select new
                    {
                        Patient = patient.FirstName + ' ' + patient.LastName,
                        Doctor = employee.FirstName + ' ' + employee.LastName,
                        appointment.AppointmentDate,
                        appointment.AppointmentTime,
                        department.DepartmentCost,
                        appointment.Paid
                    };

        //var query = await _context.ExecuteGetAppointmentFor(fullName);

        return Ok(query.Where(x => x.Patient.ToLower().Contains(fullName.ToLower())));
    }

    [HttpPost("CreateMedicine")]
    public async Task<IActionResult> CreateMedicine([FromQuery] AddNewMedicine model)
    {
        await _context.ExecuteAddNewMedicineAsync(model.Name,
            model.ExpireDate,
            model.StockQuantity,
            model.UnitPrice,
            model.CurrentQuantity);

        return Ok(model);
    }

    [HttpPost("AddEmployeeToSchedual")]
    public async Task<IActionResult> AddEmployeeToSchedual([FromQuery] AddEmployeeToSchedualModel model)
    {
        var validDepartmentId = await
            _context.Departments.AnyAsync(d => d.DepartmentId == model.DepartmentId);

        bool validGender = model.Gender!.ToLower().Equals("male") ||
          model.Gender.ToLower().Equals("female");

        if (model.Salary <= 0)
            return BadRequest("Not valid");

        if (!validDepartmentId || !validGender)
            return BadRequest("Not valid department or gender");

        await _context.ExecuteAddEmployeeToScheduleAsync(model.DayOfWeek,
            model.StartTime,
            model.EndTime,
            model.FirstName!,
            model.LastName!,
            model.Gender!,
            model.JobTitle!,
            model.Salary,
            model.Phone!,
            model.DateOfBirth,
            model.DepartmentId);

        return Ok(model);
    }


    [HttpPost("CreatePatient")]
    public async Task<IActionResult> CreatePatient([FromQuery] AddPatientModel model)
    {
        if (!(model.Gender?.ToLower() == "male" || model.Gender?.ToLower() == "female"))
            return BadRequest("Gender must be male or female");

        await _context.ExecuteAddPatientAsync(model.FirstName,
            model.LastName, model.Gender, model.Phone, model.Email);

        return Ok(model);
    }

    [HttpPost("GetAppointmentFor")]
    public async Task<IActionResult> GetAppointmentFor([FromQuery] string? fullName)
    {
        return Ok(await _context.ExecuteGetAppointmentFor(fullName));
    }

    [HttpPost("GetMedicinesSuppliedBy")]
    public async Task<IActionResult> GetMedicinesSuppliedByAsync([FromQuery] int supplierId)
    {
        return Ok(await _context.ExecuteGetMedicinesSuppliedBy(supplierId));
    }

    [HttpPost("GetPatientsByFullName")]
    public async Task<IActionResult> GetPatientsByFullNameAsync([FromQuery] string fullName)
    {
        return Ok(await _context.ExecuteGetPateintsByFullName(fullName));
    }

    [HttpPost("GetPatientPrescription")]
    public async Task<IActionResult> GetPatientPrescriptionAsync([FromQuery] int prescriptionId)
    {
        return Ok(await _context.ExecuteGetPatientPrescription(prescriptionId));
    }

    [HttpPost("GetPatientWithCheckupCostByFullName")]
    public async Task<IActionResult> GetPatientWithCheckupCostByFullName(string fullName)
    {
        return Ok(await _context.ExecuteGetPatientWithCheckupCostByFullName(fullName));
    }

    [HttpPost("GetPatientCareAgenda")]
    public async Task<IActionResult> GetPatientCareAgendaAsync(int employeeId)
    {
        return Ok(await _context.ExecutePatientCareAgenda(employeeId));
    }

    [HttpPost("SearchDoctorBy")]
    public async Task<IActionResult> SearchDoctorByAsync(string doctorName)
    {
        return Ok(await _context.ExecuteSearchDoctorBy(doctorName));
    }

    [HttpPost("SearchEmployeeBy")]
    public async Task<IActionResult> SearchEmployeeByAsync(string employeeName)
    {
        return Ok(await _context.ExecuteSearchEmployeeBy(employeeName));
    }

    [HttpPost("UpdateEmployeeSalary")]
    public async Task<IActionResult> UpdateEmployeeSalary(int employeeId, decimal newSalary)
    {
        var validEmployee = await _context.Employees.AnyAsync(e => e.EmployeeId == employeeId);

        if (!validEmployee || newSalary <= 0)
            return BadRequest("Not valid");

        await _context.ExecuteUpdateEmployeeSalaryAsync(employeeId, newSalary);

        return Ok("Updated Successfully");
    }

    [HttpPost("PaymentStatusForPatient")]
    public async Task<IActionResult> UpdatePaymentStatusForPatientAsync(int appointmentId)
    {
        var validAppointment = await _context.Appointments.AnyAsync(e => e.AppointmentId == appointmentId);

        if (!validAppointment)
            return BadRequest("Not valid");

        await _context.ExecuteUpdatePaymentStatusForPatientAsync(appointmentId);

        return Ok("Updated Successfully");
    }

    [HttpPost("SearchMedicineBy")]
    public IActionResult SearchMedicineBy([FromBody] string medicineName)
    {
        var query = from medicine in _context.Medicines
                    join medicineDosage in _context.MedicineDosages
                    on medicine.MedicineId equals medicineDosage.MedicineId
                    where medicine.Name.ToLower().Contains(medicineName.ToLower())
                    select new
                    {
                        medicine.Name,
                        medicineDosage.Dosage,
                        medicine.ExpireDate,
                        medicine.UnitPrice,
                        medicine.StockQuantity,
                        medicine.ImagePath
                    };

        return Ok(query);
    }

    [HttpGet("GetDoctors")]
    public async Task<IActionResult> GetDoctorsAsync()
    {
        var query = await _context.Employees.Where(e => e.JobTitle.ToLower() == "doctor")
            .Include(e => e.Department)
            .Select(e => new
            {
                e.EmployeeId,
                e.FirstName,
                e.LastName,
                e.Gender,
                e.JobTitle,
                e.HireDate,
                e.Salary,
                e.DateOfBirth,
                e.Phone,
                e.ImageUrl,
                Department = e.Department.DepartmentName
            }).ToListAsync();

        if (!query.Any())
            return BadRequest("Nom doctors founded");

        return Ok(query);

    }
}
