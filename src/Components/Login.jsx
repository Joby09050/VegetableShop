import React, { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";

import "../Styles/Login.css";

const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");
  const navigate = useNavigate();
  const handleLogin = async (e) => {
    e.preventDefault();
    try {
      const apiUrl = "https://localhost:7067/api/Login/verify";
      const data = {
        userName: email,
        userPassword: password,
      };

      const response = await axios.post(apiUrl, data);
      if (response.status === 200) {
        console.log(response.data);
        navigate("/shopping");
      }
    } catch (err) {
      setError("An error occurred. Please try again.");
      console.error("Error:", err);
    }
  };

  return (
    <div>
      <div className="login_body">
        <form action="" onSubmit={handleLogin}>
          <div className="logincontainer">
            <label htmlFor="login" className="login">
              Login
            </label>
            <div className="section d-flex flex-column ms-2 me-2">
              <label
                htmlFor="userName"
                className="d-flex justify-content-start"
              >
                User Name
              </label>
              <input
                type="text"
                placeholder="Enter Your User Name"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
              />
            </div>

            <div className="section d-flex flex-column ms-2 me-2 pt-3">
              <label
                htmlFor="password"
                className="d-flex justify-content-start"
              >
                Password
              </label>
              <input
                type="password"
                placeholder="Enter Your User Password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
              />
            </div>

            <div className=" d-flex justify-content-end me-2 mt-5 mb-5">
              <input type="submit" className="submit" value="SUBMIT" />
            </div>
          </div>
        </form>
        {error && <p className="warning">{error}</p>}
      </div>
    </div>
  );
};

export default Login;
