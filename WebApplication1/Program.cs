using DataAccess.Abstract;
using DataAccess.Concrete;

var builder = WebApplication.CreateBuilder(args);


// *****************
builder.Services.AddScoped<ICategoryDal, CategoryDal>();
builder.Services.AddScoped<IFavoriteDal, FavoriteDal>();
builder.Services.AddScoped<ILearningDal, LearningDal>();
builder.Services.AddScoped<IUserDal, UserDal>();
builder.Services.AddScoped<IWordDal, WordDal>();
// *****************



// *****************
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// *****************


// *****************
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder => builder.WithOrigins("http://localhost:3000", "http://192.168.1.101:8081", "https://192.168.1.101:8081").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()); //.AllowAnyOrigin() kaldýr
});
// *****************

 

builder.Services.AddControllers();
 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// *****************
app.UseCors("AllowOrigin");
// *****************

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


 
app.UseAuthorization();

app.MapControllers();

app.Run();
