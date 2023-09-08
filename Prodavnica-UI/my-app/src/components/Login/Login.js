import React, { useRef, useState, useContext } from "react";
import { useNavigate } from "react-router-dom";
import AuthContext from "../../contexts/auth-context";
import { GoogleLogin } from "@react-oauth/google";
import { toast } from "react-toastify";

import Avatar from "@mui/material/Avatar";
import Button from "@mui/material/Button";
import Box from "@mui/material/Box";
import Grid from "@mui/material/Grid";
import TextField from "@mui/material/TextField";
import CssBaseline from "@mui/material/CssBaseline";
import Link from "@mui/material/Link";
import { InputAdornment } from '@mui/material';

import Container from "@mui/material/Container";
import Typography from "@mui/material/Typography";

import LoginIcon from '@mui/icons-material/Login';
import EmailIcon from '@mui/icons-material/Email';
import KeyIcon from '@mui/icons-material/Key';

import { createTheme, ThemeProvider } from "@mui/material/styles";

const isNotEmpty = (value) => value.trim() !== "";

const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

const Login = () => {
    const navigate = useNavigate();
    const defaultTheme = createTheme();
  
    const [data, setData] = useState({
      Email: "",
      Sifra: "",
    });

    const [isValid, setIsValid] = useState({
      email: true,
      sifra: true,
    });
  
    const emailInputRef = useRef();
    const passwordInputRef = useRef();
    const authContext = useContext(AuthContext);
  
    const emailBlurHandler = () => {
      const enteredEmail = data.Email;

      if (isNotEmpty(enteredEmail) && emailRegex.test(enteredEmail)) {
        setIsValid((valid) => ({
          ...valid,
          email: true,
        }));
      } else {
        setIsValid((valid) => ({
          ...valid,
          email: false,
        }));
      }
    };
  
    const passwordBlurHandler = () => {
      const enteredPassword = data.Sifra;

      if (isNotEmpty(enteredPassword)) {
        setIsValid((valid) => ({
          ...valid,
          sifra: true,
        }));
      } else {
        setIsValid((valid) => ({
          ...valid,
          sifra: false,
        }));
      }
    };
  
    const submitHandler = (event) => {
      event.preventDefault();
  
      const loginData = { email: data.Email, password: data.Sifra };
      authContext.onLogin(loginData).then((response) => {
        console.log(response);
      });
    };
  
     const googleLoginHandler = (response) => { 
      let data = new FormData();
       data.append("googleToken", response.credential);
     authContext.googleLogin(data);
     };
  
    const googleLoginErrorHandler = () => {
      toast.error("Google login error", {
       position: "top-center",
        autoClose: 2500,
        closeOnClick: true,
        pauseOnHover: false,
     });
     };
  
    return (
      <Box
        sx={{
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
          height: "100vh",
          backgroundColor: "lightgray",
        }}
      >
        <ThemeProvider theme={defaultTheme}>
          <Container component="main" maxWidth="xs">
          <CssBaseline />
            <Box
              sx={{
                marginTop: 5,
                display: "flex",
                flexDirection: "column",
                alignItems: "center",
              }}
            >
              <Avatar sx={{ m: 1, bgcolor: "crimson" }}>
                <LoginIcon />
              </Avatar>
              <Typography component="h1" variant="h5" sx={{ color: "Black" }}>
                Ulogujte se
              </Typography>
              <Box
                component="form"
                onSubmit={submitHandler}
                noValidate
                sx={{ mt: 1 }}
              >
                
                <TextField
                sx={{
                    width: 400,
                    "& .MuiInputBase-root": {
                        height: 50
                    }
                }}
                  InputProps={{
                    startAdornment: (
                      <InputAdornment position="start">
                        <EmailIcon style={{ color: 'crimson' }}/>
                      </InputAdornment>
                    ),
                  }}
                  inputProps={{ style: { color: "Black" } }}
                  InputLabelProps={{ style: { color: "Gray" } }}
                  margin="normal"
                  required
                  fullWidth
                  id="email"
                  label="Email"
                  name="email"
                  autoComplete="email"
                  autoFocus
                  error={!isValid.email}
                  onBlur={emailBlurHandler}
                  onChange={(e) => setData({ ...data, Email: e.target.value })}
                />
                <TextField
                sx={{
                    width: 400,
                    "& .MuiInputBase-root": {
                        height: 50
                    }
                }}
                  InputProps={{
                    startAdornment: (
                      <InputAdornment position="start">
                        <KeyIcon style={{ color: 'crimson' }}/>
                      </InputAdornment>
                    ),
                  }}
                  inputProps={{ style: { color: "Black" } }}
                  InputLabelProps={{ style: { color: "Gray" } }}
                  margin="normal"
                  required
                  fullWidth
                  name="sifra"
                  label="Šifra"
                  type="password"
                  id="sifra"
                  autoComplete="current-password"
                  error={!isValid.sifra}
                  onBlur={passwordBlurHandler}
                  onChange={(e) => setData({ ...data, Sifra: e.target.value })}
                />
                <Button
                  type="submit"
                  color="success"
                  variant="outlined"
                  fullWidth
                  sx={{ mt: 1, mb: 5 }}
                >
                  Login
                </Button>
                <Grid container>
                  <Grid item sx={{ marginLeft: 10}}>
                    <GoogleLogin
                      onSuccess={googleLoginHandler}
                      onError={googleLoginErrorHandler}
                    /> 
                    <Grid item sx={{marginTop: 2}}>
                    <Link href="/register" variant="body1" justifyContent="flex" sx={{marginLeft: 3}}>
                      {"Nemate nalog? Registruj se"}
                    </Link>
                    </Grid>
                  </Grid>
                </Grid>
              </Box>
            </Box>
          </Container>
        </ThemeProvider>
      </Box>
    );
  };
  
  export default Login;