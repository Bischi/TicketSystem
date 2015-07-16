SELECT t.id, t.title, t.content, t.date, t. time, p.description, s.description, a.description, u.fname, u.lname FROM tsystem.tbl_ticket t Inner join tbl_priority p on t.tbl_priority_id = p.id Inner join tbl_status s on t.tbl_status_id = s.id inner join tbl_area a on t.tbl_area_id = a.id Inner join tbl_ticket_has_tbl_user tu on t.id = tu.tbl_ticket_id inner join tbl_user u on tu.tbl_user_id = u.id WHERE u.id = 1;