﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ABCarriers.Models;

namespace ABCarriers.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InvoicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Invoices
        public async Task<IActionResult> Index()
        {
            return View(await _context.ViewReports.ToListAsync()); 
        }

        // GET: Invoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices
                .Include(i => i.category)
                .Include(i => i.unit)
                .Include(i => i.vendor)
                .FirstOrDefaultAsync(m => m.id == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // GET: Invoices/Create
        public IActionResult Create()
        {
            ViewData["category_id"] = new SelectList(_context.Categories, "id", "name");
            ViewData["unit_id"] = new SelectList(_context.Units, "id", "name");
            ViewData["vendor_id"] = new SelectList(_context.Vendors, "id", "name");
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,miti,invoice_no,vendor_id,location_id,category_id,quantity,rate,taxable_amount,vat_amount,total_amount,unit_id")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["category_id"] = new SelectList(_context.Categories, "id", "name", invoice.category_id);
            ViewData["unit_id"] = new SelectList(_context.Units, "id", "name", invoice.unit_id);
            ViewData["vendor_id"] = new SelectList(_context.Vendors, "id", "name", invoice.vendor_id);
            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            ViewData["category_id"] = new SelectList(_context.Categories, "id", "id", invoice.category_id);
            ViewData["unit_id"] = new SelectList(_context.Units, "id", "id", invoice.unit_id);
            ViewData["vendor_id"] = new SelectList(_context.Vendors, "id", "id", invoice.vendor_id);
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,miti,invoice_no,vendor_id,location_id,category_id,quantity,rate,taxable_amount,vat_amount,total_amount,unit_id")] Invoice invoice)
        {
            if (id != invoice.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceExists(invoice.id))
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
            ViewData["category_id"] = new SelectList(_context.Categories, "id", "id", invoice.category_id);
            ViewData["unit_id"] = new SelectList(_context.Units, "id", "id", invoice.unit_id);
            ViewData["vendor_id"] = new SelectList(_context.Vendors, "id", "id", invoice.vendor_id);
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices
                .Include(i => i.category)
                .Include(i => i.unit)
                .Include(i => i.vendor)
                .FirstOrDefaultAsync(m => m.id == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice != null)
            {
                _context.Invoices.Remove(invoice);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoices.Any(e => e.id == id);
        }
    }
}
