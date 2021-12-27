using AutoMapper;
using CleanCrud.DTOs;
using CleanCrud.Models;
using CleanCrud.Models.DTOs;

namespace CleanCrud.AutoMapperProfiles;

public class DoctorsProfiles:Profile
{
    public DoctorsProfiles()
    {
        CreateMap<Doctor, DoctorReadDTO>();
        CreateMap<DoctorCreateDTO, Doctor>();
        CreateMap<DoctorUpdateDTO, Doctor>();
        CreateMap<Issue, IssueChildReadDTO>();
        CreateMap<Patient, PatientReadDTO>();
        CreateMap<PatientCreateDTO, Patient>();
        CreateMap<PatientUpdateDTO, Patient>();
    }
}
