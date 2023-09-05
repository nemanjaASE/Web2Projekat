import { Routes, Route, Navigate } from "react-router-dom";
import React, { useContext } from "react";
import AuthContext from "../contexts/auth-context.js";

import Login from "../components/Login/Login.js";
import Register from "../components/Register/Register.js";
const AppRoutes = () => {

    const authContext= useContext(AuthContext);

    const ulogovan = authContext.ulogovan;

    return (
      <Routes>
        <Route path="/" element={ulogovan ? <Navigate to="/dashboard" /> : <Login />} />
        <Route
          path="/register"
          element={ulogovan ? <Navigate to="/dashboard" /> : <Register />}
        />
      </Routes>
    );
  };
  
  export default AppRoutes;