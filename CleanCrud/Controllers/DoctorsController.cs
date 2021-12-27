using AutoMapper;
using CleanCrud.Data;
using CleanCrud.Models;
using CleanCrud.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CleanCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IHospitalUnitOfWork _hospitalUnitOfWork;
        private readonly IMapper _mapper;

        public DoctorsController(IHospitalUnitOfWork hospitalUnitOfWork, IMapper mapper)
        {
            _hospitalUnitOfWork = hospitalUnitOfWork;
            _mapper = mapper;
        }

        // GET: api/Doctors
        [HttpGet]
        public ActionResult<IEnumerable<DoctorReadDTO>> GetDoctors()
        {
            var docs = _hospitalUnitOfWork.DoctorsRepository.GetAll().ToList();
            //.Select(doc => new DoctorReadDTO
            //{
            //    Id = doc.Id,
            //    Name = doc.Name,
            //    PerformanceRate = doc.PerformanceRate,
            //    Specialization = doc.Specialization
            //}).ToList();
            var doctorsToRead = _mapper.Map<List<DoctorReadDTO>>(docs);
            return doctorsToRead;
        }

        // GET: api/Doctors/5
        [HttpGet("{id}")]
        public ActionResult<DoctorReadDTO> GetDoctor(Guid id)
        {
            var doctor = _hospitalUnitOfWork.DoctorsRepository.Get(id);

            if (doctor == null)
            {
                return NotFound();
            }

            //var doctorToRead = new DoctorReadDTO
            //{
            //    Id = doctor.Id,
            //    Name = doctor.Name,
            //    PerformanceRate = doctor.PerformanceRate,
            //    Specialization = doctor.Specialization
            //};

            var doctorToRead = _mapper.Map<DoctorReadDTO>(doctor);
            //doctorToRead.Name = "Jamal";

            return doctorToRead;
        }

        // PUT: api/Doctors/5
        [HttpPut("{id}")]
        public ActionResult PutDoctor(Guid id, DoctorUpdateDTO doctor)
        {
            if (id != doctor.Id)
            {
                return BadRequest();
            }

            var doctorToUpdate = _hospitalUnitOfWork.DoctorsRepository.Get(id);

            if (doctorToUpdate is null)
            {
                return NotFound();
            }

            //doctorToUpdate.Name = doctor.Name;
            //doctorToUpdate.Specialization = doctor.Specialization;

            var doctorToUpdate2 = _mapper.Map<Doctor>(doctor);
            _mapper.Map(doctor, doctorToUpdate);

            _hospitalUnitOfWork.DoctorsRepository.Update(doctorToUpdate);

            var t = _hospitalUnitOfWork.DoctorsRepository.SaveChanges();


            return NoContent();
        }

        // POST: api/Doctors
        [HttpPost]
        public ActionResult<Doctor> PostDoctor(DoctorCreateDTO doctor)
        {
            //var doctorToCreate = new Doctor
            //{
            //    Id = new Guid(),
            //    Name = doctor.Name,
            //    Specialization = doctor.Specialization
            //};

            var doctorToCreate = _mapper.Map<Doctor>(doctor);
            doctorToCreate.Id = new Guid();

            _hospitalUnitOfWork.DoctorsRepository.Create(doctorToCreate);
            _hospitalUnitOfWork.DoctorsRepository.SaveChanges();

            return CreatedAtAction("GetDoctor", new { id = doctorToCreate.Id }, doctor);
        }

        // DELETE: api/Doctors/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(Guid id)
        {
            var Doctor = _hospitalUnitOfWork.DoctorsRepository.Get(id);
            if (Doctor is null)
            {
                return NotFound();
            }

            _hospitalUnitOfWork.DoctorsRepository.Delete(Doctor.Id);
            _hospitalUnitOfWork.DoctorsRepository.SaveChanges();
            return NoContent();
        }
    }
}
