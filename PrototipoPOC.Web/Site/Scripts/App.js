var InterfilePrototipoApp = new (Backbone.View.extend({
    Models: {},
    Collections: {},
    Views: {},
    events:
    {
        'click a[data-backbone]': function (e) {
            e.preventDefault();
            Backbone.history.navigate(e.target.pathname, { trigger: true });
        }
    },
    start: function (bootstrap) {
        if (bootstrap !== null && bootstrap !== undefined) {
            this.pessoas = new InterfilePrototipoApp.Collections.Pessoas(bootstrap.pessoas.toJSON());
            var pessoasView = new InterfilePrototipoApp.Views.Pessoas({ collection: this.pessoas });
            $('#app').html(pessoasView.render().el);
        }
        Backbone.history.start({ pushState: true, root: '/Site' });
    }
}))({ el: document.body });

$(document).on("templateCacheCompleted", function () {

    InterfilePrototipoApp.Models.Pessoa = Backbone.Model.extend({
        urlRoot: '/api/pessoas'
    });

    InterfilePrototipoApp.Collections.Pessoas = Backbone.Collection.extend({
        model: InterfilePrototipoApp.Models.Pessoa,
        url: '/api/pessoas'

    });

    InterfilePrototipoApp.Views.PessoaForm = Backbone.View.extend({
        template: Mustache.compile(window.templates['templatePessoa']),
        initialize: function () {
            this.listenTo(this.model, 'change', this.render);

        },
        render: function () {
            this.$el.html(this.template(this.model.attributes));
            return this;
        },
        remove: function () {
            this.$el.remove();
        }
    });


    InterfilePrototipoApp.Views.Pessoa = Backbone.View.extend({
        //template: Mustache.compile(window.templates['templatePessoa']),
        initialize: function () {
            this.listenTo(this.model, 'change', this.render);
        },
        tagName: 'tr',
        render: function () {
            this.$el.html(this.template(this.model.attributes));
            return this;
        },
        remove: function () {
            this.$el.remove();
        }
    });

    InterfilePrototipoApp.Views.Pessoas = Backbone.View.extend({
        template: Mustache.compile(window.templates['templatePessoas']),
        initialize: function () {
            this.listenTo(this.collection, 'sync', this.render);
            this.listenTo(this.collection, 'reset', this.render);
        },
        render: function () {
            this.$el.html("");
            $("<div>").appendTo(this.$el);
            this.$el.find("div").kendoGrid({
                dataSource: new kendo.Backbone.DataSource({
                    collection: this.collection,
                    schema: {
                        model: {
                            fields: {
                                id: { type: 'number' },
                                nome: { type: 'string' }
                            }
                        }
                    },
                    pageSize: 2
                }),
                groupable: {
                    messages:
                        {
                            empty: "Arraste as colunas que deseja agrupar aqui"
                        }
                },
                serverPaging: true,
                sortable: true,
                pageable: true,
                height: 230,
                columns: [
                {
                    field: 'id',
                    width: 90,
                    title: 'Id'
                }, {
                    field: 'nome',
                    width: 90,
                    title: 'Nome'
                }]
            });

            return this;
        },
        remove: function () {
            this.$el.remove();
        }
    });


    InterfilePrototipoApp.AppRouter = new (Backbone.Router.extend({
        initialize: function (options) {
            this.pessoasList = new InterfilePrototipoApp.Collections.Pessoas();
            this.pessoa = new InterfilePrototipoApp.Models.Pessoa();
        },
        routes: {
            "(Pessoas)(/)(:id)": "index",
            "(Pessoas)(/)Busca/(:nome)": "buscaPorNome",
            "*anything": "notFound"
        },
        index: function (id) {
            if (id > 0) {
                
                this.pessoa.set("id", id);
                this.pessoa.fetch();
                var pessoaView = new InterfilePrototipoApp.Views.Pessoa({ model: this.pessoa });
                pessoaView.render();
                $('#app').html(pessoaView.el);
              
            }
            else {
                this.pessoasList.fetch();
                var pessoasView = new InterfilePrototipoApp.Views.Pessoas({ collection: this.pessoasList });
                pessoasView.render();
                $('#app').html(pessoasView.el);
               
            }
        },
        notFound: function (anything) {
            console.log(anything);
        },
        buscaPorNome: function (nome) {
            this.pessoasList.fetch({ data: { nome: nome } });
            var pessoasView = new InterfilePrototipoApp.Views.Pessoas({ collection: this.pessoasList });
            pessoasView.render();
            $('#app').html(pessoasView.el);
          
        }
    }))();


    $(document).trigger("classInitialize");
});