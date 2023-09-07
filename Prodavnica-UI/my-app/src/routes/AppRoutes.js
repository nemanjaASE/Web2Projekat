import { Routes, Route, Navigate } from "react-router-dom";
import React, { useContext } from "react";
import AuthContext from "../contexts/auth-context.js";

import Login from "../components/Login/Login.js";
import Register from "../components/Register/Register.js";
import Dashboard from "../components/Dashboard/Dashboard.js";
import Profile from "../components/Profile/Profile.js";
import Verification from "../components/Verification/Verification.js";
import Product from "../components/Product/Product.js";

const AppRoutes = () => {

    const authContext= useContext(AuthContext);

    const ulogovan = authContext.ulogovan;

    return (
      <Routes>
        <Route path="/" element={ulogovan ? <Dashboard /> : <Login />} />
        <Route
          path="/register"
          element={ulogovan ? <Navigate to="/dashboard" /> : <Register />}
        />
        <Route path="/profile" element={ulogovan ? <Profile /> : <Login />} />
        <Route
          path="/dashboard"
          element={ulogovan ? <Dashboard /> : <Login />}
        />
        <Route
          path="/verification"
          element={ulogovan ? <Verification /> : <Login />}
        />
        <Route 
         path="/product" 
          element={ulogovan ? <Product /> : <Login />} 
        />
      </Routes>
    );
  };
  
  export default AppRoutes;