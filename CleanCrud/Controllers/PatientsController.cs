using AutoMapper;
using CleanCrud.Data;
using CleanCrud.DTOs;
using CleanCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CleanCrud.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly HospitalContext _context;
    private readonly IMapper _mapper;

    public PatientsController(HospitalContext injectedContext, IMapper mapper)
    {
        _context = injectedContext;
        _mapper = mapper;
    }

    //public ActionResult<List<Patient>> GetAllPatients()
    //{
    //    return Ok(_context.Patients.Include(p => p.Issues).ToList());
    //}
    [HttpGet]
    public ActionResult<List<PatientReadDTO>> GetAllPatients()
    {
        var patients = _context.Patients.Include(p => p.Issues).ToList();
        var readPatients = _mapper.Map<List<PatientReadDTO>>(patients);
        return Ok(readPatients);
    }

    [HttpPost]
    public ActionResult AddPatient(PatientCreateDTO patient)
    {
        var RelatedIssues = _context.Issues
            .Where(issue => patient.IssuesIds.Contains(issue.Id.ToString()))
            .ToList();

        var patientToCreate = _mapper.Map<Patient>(patient);
        patientToCreate.Id = new Guid();
        patientToCreate.Issues = RelatedIssues;

        _context.Patients.Add(patientToCreate);
        _context.SaveChanges();

        return Ok("Patient added!");
    }

    [HttpPut("{id}")]
    public ActionResult UpdatePatient(string id, PatientUpdateDTO patient)
    {
        if (id != patient.Id.ToString())
        {
            return BadRequest();
        }
        var patientToUpdate = _context.Patients.Find(patient.Id);
        var patientToUpdate2 = _context.Patients.Find(new Guid(id));

        if (patientToUpdate is null)
        {
            return NotFound();
        }

        _mapper.Map(patient, patientToUpdate);

        patientToUpdate.Issues.Clear();

        var RelatedIssues = _context.Issues
            .Where(issue => patient.IssuesIds.Contains(issue.Id.ToString()))
            .ToList();

        patientToUpdate.Issues = RelatedIssues;

        _context.SaveChanges();

        return NoContent();
    }
}
