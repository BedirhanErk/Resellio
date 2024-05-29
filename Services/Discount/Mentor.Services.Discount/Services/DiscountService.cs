using Dapper;
using Mentor.Shared.Dtos;
using Npgsql;
using System.Data;

namespace Mentor.Services.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbConnection;

        public DiscountService(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbConnection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSql"));
        }

        public async Task<Response<Models.Discount>> GetById(int id)
        {
            var discount = (await _dbConnection.QueryAsync<Models.Discount>("SELECT * FROM discount WHERE id = @Id", new { Id = id })).SingleOrDefault();

            if (discount == null)
                return Response<Models.Discount>.Fail("Discount not found", 404);

            return Response<Models.Discount>.Success(discount, 200);
        }

        public async Task<Response<List<Models.Discount>>> GetAll()
        {
            var discounts = await _dbConnection.QueryAsync<Models.Discount>("SELECT * FROM discount");

            return Response<List<Models.Discount>>.Success(discounts.ToList(), 200);
        }

        public async Task<Response<NoContent>> Save(Models.Discount discount)
        {
            var status = await _dbConnection.ExecuteAsync("INSERT INTO discount (userid, rate, code) VALUES (@UserId, @Rate, @Code)", discount);

            if (status > 0)
                return Response<NoContent>.Success(204);

            return Response<NoContent>.Fail("An error accured while adding", 500);
        }

        public async Task<Response<NoContent>> Update(Models.Discount discount)
        {
            var existDiscount = GetById(discount.Id).Result.Data;

            if (existDiscount == null)
                return Response<NoContent>.Fail("Discount not found", 404);

            var status = await _dbConnection.ExecuteAsync("UPDATE discount SET userid = @UserId, code = @Code, rate = @Rate WHERE id = @Id", new { Id = existDiscount.Id, UserId = discount.UserId, Code = discount.Code, Rate = discount.Rate });

            if (status > 0)
                return Response<NoContent>.Success(204);

            return Response<NoContent>.Fail("An error accured while updating", 500);
        }

        public async Task<Response<NoContent>> Delete(int id)
        {
            var existDiscount = GetById(id).Result.Data;

            if (existDiscount == null)
                return Response<NoContent>.Fail("Discount not found", 404);

            var status = await _dbConnection.ExecuteAsync("DELETE FROM discount WHERE id = @Id", new { Id = existDiscount.Id });

            if (status > 0)
                return Response<NoContent>.Success(204);

            return Response<NoContent>.Fail("An error accured while deleting", 500);
        }

        public async Task<Response<Models.Discount>> GetByCodeAndUserId(string code, string userId)
        {
            var discounts = await _dbConnection.QueryAsync<Models.Discount>("SELECT * FROM discount WHERE code = @Code AND userid = @UserId", new { Code = code, UserId = userId });

            if (discounts.FirstOrDefault() == null)
                return Response<Models.Discount>.Fail("Discount not found", 404);

            return Response<Models.Discount>.Success(discounts.FirstOrDefault(), 200);
        }
    }
}
