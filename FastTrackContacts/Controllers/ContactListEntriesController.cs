﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FastTrackContacts.Data;
using FastTrackContacts.Models;

namespace FastTrackContacts
{
    public class ContactListEntriesController : Controller
    {
        private readonly DatabaseContext _context;

        public ContactListEntriesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: ContactListEntries
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContactListEntries.ToListAsync());
        }

        // GET: ContactListEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactListEntry = await _context.ContactListEntries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactListEntry == null)
            {
                return NotFound();
            }

            return View(contactListEntry);
        }

        // GET: ContactListEntries/Create
        public IActionResult Create()
        {
            //ViewData["CompanyName"] = "BuyNLarge";
            ViewBag.CompanyName = "BuyNLarge";

            return View();
        }

        // POST: ContactListEntries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContactType,Name,DateOfBirth,Address,PhoneNumber,Email")] ContactListEntry contactListEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactListEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactListEntry);
        }

        // GET: ContactListEntries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactListEntry = await _context.ContactListEntries.FindAsync(id);
            if (contactListEntry == null)
            {
                return NotFound();
            }
            return View(contactListEntry);
        }

        // POST: ContactListEntries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ContactType,Name,DateOfBirth,Address,PhoneNumber,Email")] ContactListEntry contactListEntry)
        {
            if (id != contactListEntry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactListEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactListEntryExists(contactListEntry.Id))
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
            return View(contactListEntry);
        }

        // GET: ContactListEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactListEntry = await _context.ContactListEntries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactListEntry == null)
            {
                return NotFound();
            }

            return View(contactListEntry);
        }

        // POST: ContactListEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactListEntry = await _context.ContactListEntries.FindAsync(id);
            if (contactListEntry != null)
            {
                _context.ContactListEntries.Remove(contactListEntry);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactListEntryExists(int id)
        {
            return _context.ContactListEntries.Any(e => e.Id == id);
        }
    }
}
