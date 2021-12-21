using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OntarioTechUniversity.Data;
using OntarioTechUniversity.Models;
using MailKit.Net.Smtp;
using MimeKit; 

namespace OntarioTechUniversity.Controllers
{

    public class ItemsController : Controller
    {
        private readonly SchoolContext _context;

        public ItemsController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Items
        public async Task<IActionResult> Index(string searchString)
        {
            var items = from i in _context.Items
                        select i;
            if (!String.IsNullOrEmpty(searchString))
            {
                items = items.Where(s => s.ItemName.Contains(searchString));
            }
            
            return View(await items.ToListAsync());
        }

        // GET: Items/Details/5
        // adding the search function
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.Location)
                .FirstOrDefaultAsync(m => m.ItemID == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "LocationID");
            return View();
        }

        // POST: Items/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemID,ItemNum,ItemName,Quantity,Manufacturer,Model,ItemComment,SerialNumber,TagNumber,ProductOverview,MSDS,ProductManual,RecommendedMaintenance,WasteManagement,Certification,DateModified,LocationID")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();

                MimeMessage message = new MimeMessage();
                MailboxAddress from = new MailboxAddress("Technical Service", "notifications@ontariotechu.ca");
                message.From.Add(from);

                MailboxAddress to = new MailboxAddress("Admin", "Admin@ontariotechu.net");
                message.To.Add(to);
                message.Subject = "New Item Added";

                BodyBuilder bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = "<p> An Item was added to the inventory system<p>";
                bodyBuilder.TextBody = "An Item was added to the inventory system";

                message.Body = bodyBuilder.ToMessageBody();

                //Gmail SMTP Client Configuration 
                //SmtpClient client = new SmtpClient();
                //client.Connect("smtp.gmail.com", 465, true);
                //client.Authenticate("admin@exmaple.com", "password");

                //client.Send(message);
                //client.Disconnect(true);
                //client.Dispose();

                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "LocationID", item.LocationID);
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "LocationID", item.LocationID);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemID,ItemNum,ItemName,Quantity,Manufacturer,Model,ItemComment,SerialNumber,TagNumber,ProductOverview,MSDS,ProductManual,RecommendedMaintenance,WasteManagement,Certification,DateModified,LocationID")] Item item)
        {
            if (id != item.ItemID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.ItemID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "LocationID", item.LocationID);
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.Location)
                .FirstOrDefaultAsync(m => m.ItemID == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items.FindAsync(id);
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.ItemID == id);
        }
        //now adding the HttpPost method since it was not there before
        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }
    }
}
