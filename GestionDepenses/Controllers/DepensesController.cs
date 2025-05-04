using GestionDepenses.Data;
using GestionDepenses.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Le controlleur de l'API Depense, il contient les principaux EndPoints
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class DepensesController : ControllerBase
{
    private readonly DepenseContext _context;

    public DepensesController(DepenseContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Liste de dépenses avec pagination
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Depense>>> GetDepenses(int pageNumber = 1, int pageSize = 10)
    {
        return await _context.Depenses
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }


    /// <summary>
    /// Récupérer une dépense par Id 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Depense>> GetDepense(int id)
    {
        var depense = await _context.Depenses.FindAsync(id);

        if (depense == null)
        {
            return NotFound();
        }

        return depense;
    }


    /// <summary>
    /// Ajouter une dépense 
    /// </summary>
    /// <param name="depense"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Depense>> PostDepense(Depense depense)
    {

        if (depense.Nature == NatureDepense.Deplacement && (depense.Distance ?? 0) <= 0)
        {
            return BadRequest("Une distance supérieure à 0 km est requise pour une dépense de type déplacement.");
        }

        if (depense.Nature == NatureDepense.Restaurant && depense.NombreInvites <=0)
        {
            return BadRequest("Un nombre d'invités supérieure ou égale à zéro est requis pour une dépense de type restaurant.");
        }

        _context.Depenses.Add(depense);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetDepense), new { id = depense.Id }, depense);
    }

    /// <summary>
    /// Supprimer une dépense existante
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDepense(int id)
    {
        var depense = await _context.Depenses.FindAsync(id);
        if (depense == null)
        {
            return NotFound();
        }

        _context.Depenses.Remove(depense);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
