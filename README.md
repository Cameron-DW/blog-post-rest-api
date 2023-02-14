# .net-6.0-blog-post-web-api

Restful CRUD API using .NET 6.0 where Users can create an account, can create Posts and create/add Topics to these Posts. Users can also comment on theirs and others Posts. All user data is saved to a relational database using SQL queries.

### User

| Method | Url | Decription | Sample Valid Request Body | 
| ------ | --- | ---------- | --------------------------- |
| POST   | /api/users| Create User| [JSON](#create-user) |
| GET   | /api/users | Get All Users |  |
| GET   | /api/users/{userId] | Get User |  |
| PUT   | /api/users/{userId] | Update User | [JSON](#update-user) |
| DELETE   | /api/users/{userId] | Delete User |  |



### Post

| Method | Url | Decription | Sample Valid Request Body | 
| ------ | --- | ---------- | --------------------------- |
| POST   | /api/users/{userId}/posts | Create Post for a User| [JSON](#create-post) |
| GET   | /api/posts | Get All Posts |  |
| GET   | /api/users/{userId}/posts | Get All User Posts | |
| GET   | /api/topics/{topicId}/posts | Get All Posts of a Topic |  |
| GET   | /api/posts/{postId} | Get Post By Id |  |
| PUT   | /api/posts/{postId} | Update Post By Id | [JSON](#update-post) |
| DELETE   | /api/posts/{postId} | Delete Post By Id |  |



### Comment


| Method | Url | Decription | Sample Valid Request Body | 
| ------ | --- | ---------- | --------------------------- |
| POST   | /api/users/{userId}posts/{postId}/comments | Create Comment| [JSON](#create-comment) |
| GET   | /api/comments | Get All Comments |  |
| GET   | /api/users/{userId}/comments | Get All User Comments |  |
| GET   | /api/posts/{postsId}/comments | Get All Post Comments | |
| GET   | /api/comments/{commentId} | Get Comment By Id | |
| PUT   | /api/comments/{commentId} | Update Comment By Id | [JSON](#update-comment) |
| DELETE   | /api/comments/{commentId} | Delete Comment By Id |  |



### Topic

| Method | Url | Decription | Sample Valid Request Body | 
| ------ | --- | ---------- | --------------------------- |
| POST   | /api/topics | Create Topic | [JSON](#create-topic) |
| POST   | /api/posts/{postId}/topics/{topicId} | Add Topic to Post |  |
| GET   | /api/topics | Get All Topics |  |
| GET   | /api/posts/{postId}/topics | Get All Topics from Post |  |
| GET   | /api/topics/{topicId} | Get Topic by Id |  |
| PUT   | /api/topics/{topicId} | Update Topic by Id | [JSON](#update-topic) |
| DELETE   | /api/posts/{postId}/topics/{topicId} | Delete Topic from Post by Id |  |
| DELETE   | /api/topics/{topicId} | Delete Topic by Id |  |

## Request Body Examples

### User

##### <a id="create-user">Create User -> /api/users</a>
```json
{
  "firstName": "Maisie",
  "lastName": "Jones",
  "email": "maisiejones@gmail.com",
  "password": "Password1#"
}
```

##### <a id="update-user">Update User -> /api/users/{userId}</a>
```json
{
  	"email": "maisiejones@gmail.com",
	"password": "Password1#"
}
```

## Post


##### <a id="create-post">Create Post -> /api/users/{userId}/posts</a>
```json
{
  "title": "My Recipe",
  "content": "Step 1:..."
}
```
##### <a id="update-post">Update Post -> /api/posts/{postId}</a>
```json
{
  "title": "Updated Recipe",
  "content": "Step 1:..."
}
```
### Comment

##### <a id="create-comment">Create Comment -> /api/users/{userId}posts/{postId}/comments
```json
{
  "text": "Thanks for posting this"
}
```
  
  ##### <a id="update-comment">Update Comment -> /api/posts/{postId}</a>
```json
{
  "text": "Thanks for posting this, It was very good."
}
```
  
  ### Topic
  
##### <a id="create-topic">Create Topic -> /api/topics
```json
{
  "name": "Software",
  "description": "Any Post here is related to Software."
}
```
  
  ##### <a id="update-topic">Update Topic -> /api/topics/{topicId}
```json
{
  "name": "Software and Hardware",
  "description": "Any Post here is related to Software or Hardware."
}
```
