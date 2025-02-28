using System;
using System.Collections.Generic;
using TheCheesecakeWizard.DAL.Repository.Entities;

namespace TheCheesecakeWizard.BL.Services.Interfaces;

public interface ICheesecakeService
{
    Task<IEnumerable<Cheesecake>> GetAllCheesecakesAsync();
    Task<Cheesecake> GetCheesecakeByIdAsync(int id);
    Task<Cheesecake> CreateCheesecakeAsync(Cheesecake cheesecake);
    Task<Cheesecake> UpdateCheesecakeAsync(int id, Cheesecake cheesecake);
    Task DeleteCheesecakeAsync(int id);
}