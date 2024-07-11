create database TaskManagement

use TaskManagement

create table users (
	[user_id] char(12) primary key, 
	username varchar(max), 
	[password] varchar(max),
	created_at datetime
)

create table priorities (
	id tinyint primary key, 
	ptype varchar(max)
)

insert priorities(id, ptype) values (1, N'Low')
insert priorities(id, ptype) values (2, N'Medium')
insert priorities(id, ptype) values (3, N'High')

create table statuses (
	id tinyint primary key,
	stype varchar(max)
)

insert statuses(id, stype) values (1, N'Pending')
insert statuses(id, stype) values (2, N'In Progress')
insert statuses(id, stype) values (3, N'Completed')
insert statuses(id, stype) values (4, N'Expired')

create table tasks (
	task_id char(12) primary key, 
	[user_id] char(12), 
	title varchar(max) not null, 
	[description] varchar(max),
	due_date datetime, 
	[priority] tinyint, 
	[status] tinyint, 
	created_at datetime,
	updated_at datetime, 
	foreign key ([user_id]) references users([user_id]),
	foreign key ([priority]) references priorities(id),
	foreign key ([status]) references statuses(id)
)

