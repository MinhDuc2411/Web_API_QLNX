﻿using Microsoft.AspNetCore.Mvc;
using DATA_DuAn.Data;
using DATA_DuAn.DTO;
using DATA_DuAn.Models;
using DuAnWeb_QLNX.Repository.DanhMucXeRepository;
using DATA_DuAn.DTO.DanhMucXeDto;
using Azure.Core;
namespace DuAnWeb_QLNX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuanLyDanhMucXe : Controller
    {
        private readonly IDanhMucXeRepository idanhMucXeRepository;
        public QuanLyDanhMucXe(IDanhMucXeRepository danhMucXe)
        {
            idanhMucXeRepository = danhMucXe;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
                 var xes = idanhMucXeRepository.GetDanhMucXe();
                 return Ok(xes);
           
        }
        [HttpGet("Get-By-Id")]
        public IActionResult GetBienso(int id)
        {
            var getId = idanhMucXeRepository.GetDanhMucXe(id);
            return Ok(getId);
        }
        [HttpPost("add")]
        public IActionResult Post([FromBody]AddDanhMucXeDTO danhmucxe)
        {
            var post = idanhMucXeRepository.AddDanhMucXe(danhmucxe);
            return Ok(post);
        }
        [HttpPut("update")]
        public IActionResult Put([FromBody]AddDanhMucXeDTO danhmucxe , int id)
        {
            var Put = idanhMucXeRepository.PutDanhMucXe(danhmucxe,id);
            return Ok(Put);
        }
        [HttpDelete]
        public IActionResult DeleteById(int id) 
        {
            try
            {
                var Del = idanhMucXeRepository.Delete(id);
                return Ok(Del);
            }
            catch  
            {
                return Ok("Đang tồn tại");
            }
        }
    }
}