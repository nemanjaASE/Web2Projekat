import React from "react";

import {
  Button,
  TableCell,
  TableRow,
} from "@mui/material";

const CartItem = (props) => {
  const price = props.price;

  return (
    <TableRow>
      <TableCell sx={{ color: "black" }}>{props.name}</TableCell>
      <TableCell sx={{ color: "black" }}>{price} RSD</TableCell>
      <TableCell sx={{ color: "black" }}>x{props.amount}</TableCell>
      <TableCell>
        <Button
          sx={{ ml: 2, mt: 1}}
          variant="contained"
          color="success"
          onClick={props.onAdd}
        >
          +
        </Button>
        <Button
          sx={{ ml: 2, mt: 1 }}
          variant="contained"
          color="error"
          onClick={props.onRemove}
        >
          -
        </Button>
      </TableCell>
    </TableRow>
  );
};

export default CartItem;