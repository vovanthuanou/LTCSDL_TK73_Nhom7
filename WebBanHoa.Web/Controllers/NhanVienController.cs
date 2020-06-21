﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebBanHoa.Web.Controllers
{
    using BLL;
    using DAL.Models;
    using Common.Req;
    using Common.Rsp;
    using WebBanHoa.Common.Rep;

    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        public NhanVienController()
        {
            _svc = new NhanVienSvc();
        }

        [HttpPost("get_nhan-vien_theo_manv")]
        public IActionResult getNhanVienById([FromBody]SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Id);
            return Ok(res);
        }

        [HttpPost("get-all")]
        public IActionResult getAllNhanVienById()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);
        }

        [HttpPost("search_NhanVien")]
        public IActionResult SearchNhanVienCtrl([FromBody] SearchNhanVienReq req)
        {
            var res = new SingleRsp();
            var pros = _svc.SearchNhanVien(req.Keyword, req.Page, req.Size);
            res.Data = pros;

            return Ok(res);
        }

        [HttpPost("create_nhanvien")]
        public IActionResult CreateNhanVien([FromBody]NhanVienreq req)
        {
            var res = _svc.CreateNhanVien(req);
            return Ok(res);
        }

        [HttpPost("update_nhanvien")]
        public IActionResult UpdateNhanVien([FromBody]NhanVienreq req)
        {
            var res = _svc.UpdateNhanVien(req);
            return Ok(res);
        }

        [HttpPost("delete-nhanvien")]
        public IActionResult DeleteNhanVien(DeleteNhanVienReq req)
        {
            var res = _svc.DeleteNhanVien(req.MaNv);

            return Ok(res);
        }

        private readonly NhanVienSvc _svc;
    }
}