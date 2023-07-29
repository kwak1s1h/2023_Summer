const fs = require('fs');
const path = require('path');
const Product = require("./product");

const rootDir = require('../util/path.js')
const filePath = path.join(rootDir, "data", "cart.json");

module.exports = class Cart {
  static addProduct(id, productPrice) {
    fs.readFile(filePath, (err, content) => {
      let cart = { products: [], totalPrice: 0 };
      if (!err) {
        cart = JSON.parse(content);
      }

      const existingProductIndex = cart.products.findIndex(p => p.id === id);
      const existingProduct = cart.products[existingProductIndex];
      let updatedProduct;
      if (existingProduct) {
        updatedProduct = { ...existingProduct };
        updatedProduct.qty = updatedProduct.qty + 1;
        cart.products = [...cart.products];
        cart.products[existingProductIndex] = updatedProduct;
      }
      else {
        updatedProduct = { id, qty: 1 };
        cart.products = [...cart.products, updatedProduct];
      }
      cart.totalPrice += new Number(productPrice);
      fs.writeFile(filePath, JSON.stringify(cart), (err) => {
        console.error(err);
      });
    });
  }
}