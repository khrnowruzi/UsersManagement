import React, { useEffect, useState } from "react";
import axios from "axios";

const User = () => {
  const [users, setUsers] = useState([]);

  useEffect(() => {
    const getUsers = async () => {
      const response = await axios.get(
        "http://localhost:5220/api/Users/GetAllUsers"
      );

      setUsers(response.data);
    };

    getUsers();
  }, []);

  return (
    <div>
      <h1>Users</h1>
      <ul>
        {users.map((item) => {
          return <li key={item.Id}>{item.firstName}</li>;
        })}
      </ul>
    </div>
  );
};

export default User;
