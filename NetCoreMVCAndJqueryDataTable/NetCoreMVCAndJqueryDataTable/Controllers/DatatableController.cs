using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreMVCAndJqueryDataTable.Utils.JqueryDatatable;
using NetCoreMVCAndJqueryDataTable.Models;

namespace NetCoreMVCAndJqueryDataTable.Controllers
{
    public class DatatableController : Controller
    {
        List<CustomerViewModel> listCustomer = new List<CustomerViewModel>();
        public DatatableController()
        {
            listCustomer = new List<CustomerViewModel>()
            {
                new CustomerViewModel()
                {
                    Id = 1,
                    Name = "Hung",
                    City = "Ho chi minh",
                    District = "Go vap",
                    Ward = "F 3",
                    Address = "Nguyen Kiem"
                },
                new CustomerViewModel()
                {
                    Id = 2,
                    Name = "lan",
                    City = "Ho chi minh",
                    District = "Go vap",
                    Ward = "F 3",
                    Address = "Nguyen Kiem"
                },
                new CustomerViewModel()
                {
                    Id = 2,
                    Name = "Minh",
                    City = "Ho chi minh",
                    District = "Go vap",
                    Ward = "F 3",
                    Address = "Nguyen Kiem"
                },
                new CustomerViewModel()
                {
                    Id = 2,
                    Name = "Tri",
                    City = "Ho chi minh",
                    District = "Go vap",
                    Ward = "F 3",
                    Address = "Nguyen Kiem"
                },
                new CustomerViewModel()
                {
                    Id = 2,
                    Name = "Tung",
                    City = "Ho chi minh",
                    District = "Go vap",
                    Ward = "F 3",
                    Address = "Nguyen Kiem"
                },
                new CustomerViewModel()
                {
                    Id = 2,
                    Name = "Quang",
                    City = "Ho chi minh",
                    District = "Go vap",
                    Ward = "F 3",
                    Address = "Nguyen Kiem"
                },
                new CustomerViewModel()
                {
                    Id = 2,
                    Name = "Minh",
                    City = "Ho chi minh",
                    District = "Go vap",
                    Ward = "F 3",
                    Address = "Nguyen Kiem"
                },
                new CustomerViewModel()
                {
                    Id = 2,
                    Name = "Tri",
                    City = "Ho chi minh",
                    District = "Go vap",
                    Ward = "F 3",
                    Address = "Nguyen Kiem"
                },
                new CustomerViewModel()
                {
                    Id = 2,
                    Name = "Tung",
                    City = "Ho chi minh",
                    District = "Go vap",
                    Ward = "F 3",
                    Address = "Nguyen Kiem"
                },
                new CustomerViewModel()
                {
                    Id = 2,
                    Name = "Quang",
                    City = "Ho chi minh",
                    District = "Go vap",
                    Ward = "F 3",
                    Address = "Nguyen Kiem"
                },
                new CustomerViewModel()
                {
                    Id = 2,
                    Name = "Minh",
                    City = "Ho chi minh",
                    District = "Go vap",
                    Ward = "F 3",
                    Address = "Nguyen Kiem"
                },
                new CustomerViewModel()
                {
                    Id = 2,
                    Name = "Tri",
                    City = "Ho chi minh",
                    District = "Go vap",
                    Ward = "F 3",
                    Address = "Nguyen Kiem"
                },
                new CustomerViewModel()
                {
                    Id = 2,
                    Name = "Tung",
                    City = "Ho chi minh",
                    District = "Go vap",
                    Ward = "F 3",
                    Address = "Nguyen Kiem"
                },
                new CustomerViewModel()
                {
                    Id = 2,
                    Name = "Quang",
                    City = "Ho chi minh",
                    District = "Go vap",
                    Ward = "F 3",
                    Address = "Nguyen Kiem"
                }
            };
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(CustomDataTableRequestHelper request)
        {
            #region " [ Main processing ] "

            // Process sorting column
            request = request.SetOrderingColumnName();

            #endregion

            //Call to service
            Dictionary<string, object> _return = List(request);
            //
            if ((int)_return[DatatableCommonSetting.Response.STATUS] == 1)
            {
                DataTableResponseHelper<CustomerViewModel> itemResponse = _return[DatatableCommonSetting.Response.DATA] as DataTableResponseHelper<CustomerViewModel>;
                return Json(itemResponse);
            }
            //
            return Json(new DataTableResponseHelper<CustomerViewModel>());
        }

        /// <summary>
        /// Get list data using jquery datatable
        /// </summary>
        /// <param name="request">Jquery datatable request</param>
        /// <param name="userID">The user identifier</param>
        /// <returns><string, object></returns>
        public Dictionary<string, object> List(CustomDataTableRequestHelper request)
        {
            Dictionary<string, object> _return = new Dictionary<string, object>();
            try
            {
                //Declare response data to json object
                DataTableResponseHelper<CustomerViewModel> _itemResponse = new DataTableResponseHelper<CustomerViewModel>();
                //List of data
                List<CustomerViewModel> _list = new List<CustomerViewModel>();

                _itemResponse.draw = request.draw;
                _itemResponse.recordsTotal = this.listCustomer.Count();

                //Search
                if (request.search != null && !string.IsNullOrWhiteSpace(request.search.Value))
                {
                    string searchValue = request.search.Value.ToLower();
                    _list = this.listCustomer.Where(m => m.Name.ToLower().Contains(searchValue)).ToList();
                }

                _list = this.listCustomer;

                _itemResponse.recordsFiltered = _list.Count;
                IOrderedEnumerable<CustomerViewModel> _sortList = null;
                if (request.order != null)
                {
                    foreach (var col in request.order)
                    {
                        switch (col.ColumnName)
                        {
                            case "id":
                                _sortList = _sortList == null ? _list.Sort(col.Dir, m => m.Id) : _sortList.Sort(col.Dir, m => m.Id);
                                break;
                            case "name":
                                _sortList = _sortList == null ? _list.Sort(col.Dir, m => m.Name) : _sortList.Sort(col.Dir, m => m.Name);
                                break;
                            case "city":
                                _sortList = _sortList == null ? _list.Sort(col.Dir, m => m.City) : _sortList.Sort(col.Dir, m => m.City);
                                break;
                            case "district":
                                _sortList = _sortList == null ? _list.Sort(col.Dir, m => m.District) : _sortList.Sort(col.Dir, m => m.District);
                                break;
                            case "ward":
                                _sortList = _sortList == null ? _list.Sort(col.Dir, m => m.Ward) : _sortList.Sort(col.Dir, m => m.Ward);
                                break;
                            case "address":
                                _sortList = _sortList == null ? _list.Sort(col.Dir, m => m.Address) : _sortList.Sort(col.Dir, m => m.Address);
                                break;
                        }
                    }
                    _itemResponse.data = _sortList.Skip(request.start).Take(request.length).ToList();
                }
                else
                {
                    _itemResponse.data = _list.Skip(request.start).Take(request.length).ToList();
                }
                _return.Add(DatatableCommonSetting.Response.DATA, _itemResponse);
                _return.Add(DatatableCommonSetting.Response.STATUS, 1);

            }
            catch (Exception ex)
            {
                throw;
            }
            return _return;
        }
    }
}