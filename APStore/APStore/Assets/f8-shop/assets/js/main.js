let homeProduct = document.querySelector('.list-product');
let arr = [
    {
        img: "url('./assets/img/product.png')",
        name: 'Set kem mắt tái sinh Ohui The First Geniture Eye Cream Edition Grand Blue',
        oldPrice: 4600000,
        newPrice: 4140000,
        like: true,
        start: 4,
        sold: 88,
        originBrand: 'Whoo',
        originName: 'Nhật bản',
        love: true,
        saleOfPercent: 43
    }, {
        img: "url('./assets/img/product.png')",
        name: 'Set kem mắt tái sinh Ohui The First Geniture Eye Cream Edition Grand Blue',
        oldPrice: 4600000,
        newPrice: 4140000,
        like: true,
        start: 4,
        sold: 88,
        originBrand: 'Whoo',
        originName: 'Nhật bản',
        love: false,
        saleOfPercent: 43
    },
    {
        img: "url('./assets/img/product.png')",
        name: 'Set kem mắt tái sinh Ohui The First Geniture Eye Cream Edition Grand Blue',
        oldPrice: 4600000,
        newPrice: 4140000,
        like: false,
        start: 4,
        sold: 88,
        originBrand: 'Whoo',
        originName: 'Nhật bản',
        love: true,
        saleOfPercent: 23
    },
    {
        img: "url('./assets/img/product.png')",
        name: 'Set kem mắt tái sinh Ohui The First Geniture Eye Cream Edition Grand Blue',
        oldPrice: 4600000,
        newPrice: 4140000,
        like: false,
        start: 4,
        sold: 88,
        originBrand: 'Whoo',
        originName: 'Nhật bản',
        love: true,
        saleOfPercent: 23
    },
    {
        img: "url('./assets/img/product.png')",
        name: 'Set kem mắt tái sinh Ohui The First Geniture Eye Cream Edition Grand Blue',
        oldPrice: 4600000,
        newPrice: 4140000,
        like: false,
        start: 4,
        sold: 88,
        originBrand: 'Whoo',
        originName: 'Nhật bản',
        love: true,
        saleOfPercent: 23
    },
    {
        img: "url('./assets/img/product.png')",
        name: 'Set kem mắt tái sinh Ohui The First Geniture Eye Cream Edition Grand Blue',
        oldPrice: 4600000,
        newPrice: 4140000,
        like: false,
        start: 4,
        sold: 88,
        originBrand: 'Whoo',
        originName: 'Nhật bản',
        love: true,
        saleOfPercent: 23
    },
    {
        img: "url('./assets/img/product.png')",
        name: 'Set kem mắt tái sinh Ohui The First Geniture Eye Cream Edition Grand Blue',
        oldPrice: 4600000,
        newPrice: 4140000,
        like: false,
        start: 4,
        sold: 88,
        originBrand: 'Whoo',
        originName: 'Nhật bản',
        love: true,
        saleOfPercent: 23
    },
    {
        img: "url('./assets/img/product.png')",
        name: 'Set kem mắt tái sinh Ohui The First Geniture Eye Cream Edition Grand Blue',
        oldPrice: 4600000,
        newPrice: 4140000,
        like: false,
        start: 4,
        sold: 88,
        originBrand: 'Whoo',
        originName: 'Nhật bản',
        love: true,
        saleOfPercent: 23
    },
    {
        img: "url('./assets/img/product.png')",
        name: 'Set kem mắt tái sinh Ohui The First Geniture Eye Cream Edition Grand Blue',
        oldPrice: 4600000,
        newPrice: 4140000,
        like: false,
        start: 4,
        sold: 88,
        originBrand: 'Whoo',
        originName: 'Nhật bản',
        love: true,
        saleOfPercent: 23
    }
]

arr.map((item, index) => {
    let productCard = `
    <!-- Produce item -->
    <a class="home-produce-item" href="#">
        <div class="home-produce-item__img" style="background-image: ${item.img};"></div>
        <h4 class="home-produce-item__name">${item.name}</h4>
        <div class="home-produce-item__price">
            <span class="home-produce-item__price-old">${item.oldPrice}đ</span>
            <span class="home-produce-item__price-new">${item.newPrice}đ</span>
        </div>
        <div class="home-produce-item__action">
            <span class="home-produce-item__like ${item.like ? `home-produce-item__liked` : ``}">
                <i class="home-produce-item__like-icon--empty far fa-heart"></i>
                <i class="home-produce-item__like-icon--fill fas fa-heart"></i>
            </span>

            <div class="home-produce-item__rating">
                <i class="home-produce-item__star-gold fas fa-star"></i>
                <i class="home-produce-item__star-gold fas fa-star"></i>
                <i class="home-produce-item__star-gold fas fa-star"></i>
                <i class="home-produce-item__star-gold fas fa-star"></i>
                <i class="fas fa-star"></i>
            </div>
            <span class="home-produce-item__sold">${item.sold} đã bán</span>
        </div>
        <div class="home-produce-item__origin">
            <span class="home-produce-item__origin-brand">${item.originBrand}</span>
            <span class="home-produce-item__origin-name">${item.originName}</span>
        </div>
        ${item.love ? `<div class="home-produce-item__favourite">
            <i class="fas fa-check"></i>
            <span>Yêu thích</span> 
        </div>`: ''}
        <div class="home-produce-item__sale-off">
            <span class="home-produce-item__sale-off-percent">${item.saleOfPercent}%</span>
            <span class="home-produce-item__sale-off__sale-off-label">Giảm</span>
        </div>
    </a>`;

    let d = document.createElement('div');
    d.setAttribute("class", "col-lbr l-2-4 m-4 c-6-lbr")
    d.innerHTML = productCard;
    var currentProduct = homeProduct.innerHTML;
    homeProduct.append(d);
})

