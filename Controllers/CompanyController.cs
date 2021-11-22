using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Probeaufgabe.Helper;
using Probeaufgabe.Models;
using Probeaufgabe.Repository;
using Probeaufgabe.ViewModels;

namespace WebApplication1.Controllers
{
    [Authorize]
    
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IAddressLink _addressLinkRepository;

        public CompanyController(ICompanyRepository companyRepository,IAddressRepository addressRepository,IAddressLink addressLinkRepository)
        {
            _companyRepository = companyRepository;
            _addressRepository = addressRepository;
            _addressLinkRepository = addressLinkRepository;
        }
        public ActionResult Index()
        {
            List<CompanyViewModel> model = new List<CompanyViewModel>();

                var companies = _companyRepository.GetAllCompanies();
              
                foreach (var result in companies)
                {
                    CompanyViewModel companyViewModel = new CompanyViewModel
                    {
                        CompanyId = result.CompanyId, CompanyName = result.CompanyName, CompanyNr = result.CompanyNr, EmailAddress = result.EmailAddress 
                    };
                    model.Add(companyViewModel);
                }

            return View(model);
        }


        public ActionResult Register()
        {
            RegistrationCompanyViewModel model = new RegistrationCompanyViewModel();
            return View(model);
        }

        
        [HttpPost]
        
        public async Task<ActionResult> Register(RegistrationCompanyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var company = CompanyHelper.ConvertDTO(model);
                await _companyRepository.InsertCompany(company);
                List<AddressLink> adressLinks = new List<AddressLink>();

                if (model.AdressType == true)
                {
                    var addressLinkPost = new AddressLink();
                    addressLinkPost.AdressType = "post";
                    var address = AddressHelper.ConvertDTO(model, addressLinkPost.AdressType);
                    await _addressRepository.InsertAddress(address);
                    addressLinkPost.Address = address;
                    addressLinkPost.Company = company;
                    adressLinks.Add(addressLinkPost);
                   
                }
                var addressLink = new AddressLink();
                addressLink.AdressType = "main";
                var addressmain = AddressHelper.ConvertDTO(model, addressLink.AdressType);
                await _addressRepository.InsertAddress(addressmain);
                addressLink.Address = addressmain;
                addressLink.Company = company;
                adressLinks.Add(addressLink);
                await _addressLinkRepository.InsertAddressLink(adressLinks);

                return RedirectToAction("index", "Company");


            }
           
                return View(model);
            
        }
        [Route("Company/Edit/{CompanyId}")]
        // GET: CompanyController/Edit/5
        public ActionResult Edit(int CompanyId)
        {
            var addressLink = _addressLinkRepository.GetAddressLinkId(CompanyId);
            var model = AddressLinksHelper.ConvertOTD(addressLink);
            return View(model);
           
        }

        // POST: CompanyController/Edit/5
        [HttpPost]
        [Route("Company/Edit/{CompanyId}")]
       
        public async Task<ActionResult> Edit(int CompanyId,EditCompanyViewModel model)
        {
            //Recommended to use AutoMapper, but because i don't have experience in it i tried to simulate it
            if (ModelState.IsValid)
            {
                var company = CompanyHelper.ConvertDTO(model);
                await _companyRepository.UpdateCompany(company);
                var addressLinks = _addressLinkRepository.GetAddressLinkId(CompanyId);
                List<AddressLink> adressLinksnew = new List<AddressLink>();
                if (model.AdressType == true)
                {
                    if (addressLinks.Count == 1)
                    {
                        var addresslink = new AddressLink();
                        addresslink.AdressType = "post";
                        var addresnew= AddressHelper.ConvertDTO(model, addresslink.AdressType);
                        await _addressRepository.InsertAddress(addresnew);
                        addresslink.Address = addresnew;
                        addresslink.Company = company;
                        adressLinksnew.Add(addresslink);
                        await _addressLinkRepository.InsertAddressLink(adressLinksnew);

                    }
                    else
                    {
                        addressLinks[1].AdressType = "post";
                        var addresspost = _addressRepository.GetAddressById(addressLinks[1].Address.AddressId);
                        addresspost = AddressHelper.ConvertDTO(model, addressLinks[1].AdressType, addresspost);

                        await _addressRepository.UpdateAddress(addresspost);
                        addressLinks[1].Address = addresspost;
                        addressLinks[1].Company = company;
                        
                        await _addressLinkRepository.UpdateAddressLink(addressLinks[1]);
                    }
                  
                }
                addressLinks[0].AdressType = "main";
                var address = _addressRepository.GetAddressById(addressLinks[0].Address.AddressId);
                 address = AddressHelper.ConvertDTO(model, addressLinks[0].AdressType,address);
                
                await _addressRepository.UpdateAddress(address);
                addressLinks[0].Address = address;
                addressLinks[0].Company = company;

                await _addressLinkRepository.UpdateAddressLink(addressLinks[0]);

                return RedirectToAction("index", "Company");


            }

            return View(model);

        }


        // POST: CompanyController/Delete/5
        [HttpPost]
        [Route("Company/Delete/{CompanyId}")]
     
        public async Task<ActionResult> Delete(int CompanyId)
        {
            var addressLinks = _addressLinkRepository.GetAddressLinkId(CompanyId);
           await _addressLinkRepository.DeleteAddressLink(CompanyId);
            foreach(var addressLink in addressLinks)
            {
                await _addressRepository.DeleteAddress(addressLink.AddressID);
            }
           
            await _companyRepository.DeleteCompany(CompanyId);

            return RedirectToAction("index", "Company");
        }
    }
}
