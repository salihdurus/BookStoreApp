﻿using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBookService> _bookService;
        private readonly Lazy<IAuthenticationService> authenticationService;
        public ServiceManager(
            IRepositoryManager repositoryManager,
            ILoggerService loggerService,
            IMapper mapper,
            IBookLinks bookLinks,
            UserManager<User> userManager,
            IConfiguration configuration)
        {
            _bookService = new Lazy<IBookService>(() => new BookManager(repositoryManager, loggerService, mapper, bookLinks));
            authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationManager(loggerService, mapper, userManager, configuration));
        }
        public IBookService BookService => _bookService.Value;

        public IAuthenticationService AuthenticationService => authenticationService.Value;
    }
}
