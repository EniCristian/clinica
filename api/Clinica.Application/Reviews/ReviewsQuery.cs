using AutoMapper;
using Clinica.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Application.Reviews;

public record ReviewsQuery : IRequest<IEnumerable<ReviewDto>>;

public class ReviewsQueryHandler : IRequestHandler<ReviewsQuery, IEnumerable<ReviewDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ReviewsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReviewDto>> Handle(ReviewsQuery request, CancellationToken cancellationToken)
    {
        var reviews = await _context.PatientReviews
            .Include(x => x.Patient)
            .ToListAsync(cancellationToken);

        return _mapper.Map<IEnumerable<ReviewDto>>(reviews);
    }
}