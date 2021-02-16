using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Responses;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _IPostService;
        private readonly IMapper _mapper;
        public PostController(IPostService IPostService, IMapper mapper)
        {
            _IPostService = IPostService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts =  _IPostService.GetPosts();
            var PostsDto = _mapper.Map<IEnumerable<PostDto>>(posts);
            var response = new ApiGenericResponse<IEnumerable <PostDto>>(PostsDto);

            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostsByUser(int id)
        {
           //var posts = _mapper.Map<Post>(postDto);
           var posts =  await _IPostService.GetPostsByUser(id);

            //var PostsDto = _mapper.Map<IEnumerable<PostDto>>(posts);

           // var response = new ApiGenericResponse<IEnumerable<PostDto>>(PostsDto);

            return Ok(posts);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> getPost(int id) {
        //    var posts = await _IPostService.GetPost(id);

        //    var postDto = _mapper.Map<PostDto>(posts);
        //    var response = new ApiGenericResponse<PostDto>(postDto);

        //    return Ok(response);
        //}

        [HttpPost]
        public async Task<IActionResult> CreatePost(PostDto postDto)
        {

            var posts = _mapper.Map<Post>(postDto);
            await _IPostService.CreatePost(posts);

            postDto = _mapper.Map<PostDto>(posts);
            var response = new ApiGenericResponse<PostDto>(postDto);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var posts = await _IPostService.DeletePost(id);
            return Ok(posts);
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePost(int id,PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
                post.Id = id;
            if (id == 0)
            {
                throw new Exception("IT CANT BE NULL");
            }
            else
            {

                await _IPostService.UpadatePost(post);
                postDto = _mapper.Map<PostDto>(post);
                var response = new ApiGenericResponse<PostDto>(postDto);


                return Ok(response);
            }
        }
    }
}
