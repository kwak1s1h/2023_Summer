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

  static deleteProduct(id, productPrice) {
    fs.readFile(filePath, (err, content) => {
      if(err) {
        return;
      }
      const updatedCart = { ...JSON.parse(content) };
      const product = updatedCart.products.find(prod => prod.id === id);
      if(!product) {
        return;
      }
      const productQty = product.qty;
      updatedCart.products = updatedCart.products.filter(prod => prod.id !== id);
      updatedCart.totalPrice = updatedCart.totalPrice - productPrice * productQty;

      fs.writeFile(filePath, JSON.stringify(updatedCart), (err) => {
        console.error(err);
      });
    });
  }

  static getCart(cb) {
    fs.readFile(filePath, (err, content) => {
      const cart = JSON.parse(content);
      if(err) {
        cb(null);  
      } else {
        cb(cart)
      }
    });
  }
}