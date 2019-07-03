using AngularWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularWeb.Controllers
{
    public class PlayerController : Controller
    {
        private CrudContext _context = null;

        public PlayerController()
        {
            _context = new CrudContext();
        }

        // GET: Player
        public JsonResult GetPlayers()
        {
            List<Player> listPlayers = _context.Players.ToList();
            return Json(new { list = listPlayers }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPlayerById(int id)
        {
            Player player = _context.Players.Where(x => x.PlayerId == id).SingleOrDefault();
            return Json(new { player = player }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddPlayer(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
            return Json(new { status = "Player added successfully" });
        }

        public JsonResult UpdatePlayer(Player player)
        {
            _context.Entry(player).State = EntityState.Modified;
            _context.SaveChanges();
            return Json(new { status = "Player updated successfully" });
        }

        public JsonResult DeletePlayer(int id)
        {
            Player player = _context.Players.Where(x => x.PlayerId == id).SingleOrDefault();
            _context.Players.Remove(player);
            _context.SaveChanges();
            return Json(new { status = "Player Deleted successfully" });
        }
    }
}