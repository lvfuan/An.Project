(function (vue) {
    // html模板信息
    var template = '<div class="page-bar"> \
                     <ul> \
                       <li><a class="{{ setButtonClass(0) }}" v-on:click="prvePage(cur)">上一页</a></li> \
                       <li v-for="index in indexs"  v-bind:class="{ active: cur == index }"> \
                          <a v-on:click="btnClick(index)">{{ index < 1 ? "..." : index }}</a> \
                       </li> \
                       <li><a class="{{ setButtonClass(1) }}" v-on:click="nextPage(cur)">下一页</a></li> \
                       <li><input type="text" placeholder="1" value="1" class="page_index"><a class="page_Content" v-on:click="page_Content(cur)">跳转</a></li>\
                       <li><span class="page_Content">第<span class="span_bar" id="page_Index">1</span>页/共<span class="span_bar" id="pageCount"></span>页</span></li> \
                     </ul > \
                   </div > '

    var pagination = vue.extend({
        template: template,
        props: ['cur', 'all'],
        computed: {
            indexs: function () {
                var left = 1
                var right = this.all
                var ar = []
                if (this.all >= 11) {
                    if (this.cur > 5 && this.cur < this.all - 4) {
                        left = this.cur - 5
                        right = this.cur + 4
                    } else {
                        if (this.cur <= 5) {
                            left = 1
                            right = 10
                        } else {
                            right = this.all
                            left = this.all - 9
                        }
                    }
                }
                while (left <= right) {
                    ar.push(left)
                    left++
                }
                if (ar[0] > 1) {
                    ar[0] = 1;
                    ar[1] = -1;
                }
                if (ar[ar.length - 1] < this.all) {
                    ar[ar.length - 1] = this.all;
                    ar[ar.length - 2] = 0;
                }
                return ar
            }
        },
        methods: {
            // 页码点击事件
            btnClick: function (data) {
                if (data < 1) return;
                if (data != this.cur) {
                    this.cur = data;
                    VueAjax(data, this.$_pageSize)
                    // this.$dispatch('btn-click', data)
                }
            },
            // 下一页
            nextPage: function (data) {
                if (this.cur >= this.all) return;
                var i = this.cur + 1;
                this.btnClick(i)
                VueAjax(i, this.$_pageSize)
            },
            // 上一页
            prvePage: function (data) {
                if (this.cur <= 1) return;
                var i = this.cur - 1;
                this.btnClick(i);
                VueAjax(i, this.$_pageSize)
            },
            // 设置按钮禁用样式
            setButtonClass: function (isNextButton) {
                if (isNextButton) {
                    return this.cur >= this.all ? "page-button-disabled" : ""
                }
                else {
                    return this.cur <= 1 ? "page-button-disabled" : ""
                }
            },
            //跳转页码
            page_Content: function (data) {
                var i = parseInt($(".page_index").val());
                if (i >this.all) return;
                this.cur = i;
                VueAjax(i, this.$_pageSize);
            }
        }
    })
    vue.Pagination = pagination

})(Vue)

function VueAjax(pageIndex, pageSize) {
    $("#page_Index").text(pageIndex);
    $.ajax({
        type: 'post',
        data: {
            pageIndex: pageIndex, pageSize: pageSize
        },
        url: 'VuePager/Index',
        success: function (res) {
            pageTable.Items = JSON.parse(res).Items
            //console.log(this.pageTable)
            //this.pageTable._data.Items = JSON.parse(res).Items;
        }

    })

}